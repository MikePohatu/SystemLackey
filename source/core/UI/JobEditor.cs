//    JobEditor.cs: Provides methods for editing the Job class
//    Copyright (C) 2015 Mike Pohatu

//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; version 2 of the License.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License along
//    with this program; if not, write to the Free Software Foundation, Inc.,
//    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using SystemLackey.Tasks;
using SystemLackey.Messaging;

namespace SystemLackey.UI
{
    public static class JobEditor
    {
        //insert a new task after the specified step
        //create and return a new step. 
        public static Step Insert(ITask pTask, Step pPrev)
        {
            Step newStep = new Step(pPrev.Parent,pTask);
            
            newStep.Next = pPrev.Next;
            if (pPrev.Next != null)
            {
                newStep.Next.Prev = newStep; 
            }

            pPrev.Next = newStep;
            newStep.Prev = pPrev;
            return newStep;
        }

        //insert an existing step below the specified step
        public static void Insert(Step pNew, Step pPrev)
        {
            InsertBelow(pNew, pPrev);
        }

        public static void InsertBelow(Step pNew, Step pTarget)
        {
            //debugging test
            //pTarget.SendMessage(pTarget, new MessageEventArgs("test", 1));           
            pNew.Next = pTarget.Next;

            if (pTarget.Next != null) { pNew.Next.Prev = pNew; }

            pNew.Parent = pTarget.Parent; //reset the parent in case this step is coming from another job or sub job
            pTarget.Next = pNew;
            pNew.Prev = pTarget;
        }

        //insert an existing step after the specified step
        //returns true if the inserted step is the new root step in the job
        public static bool InsertAbove(Step pNew, Step pTarget)
        {
            bool isNewRoot = false;
            
            pNew.Prev = pTarget.Prev;

            if (pTarget.Prev == null) 
            { 
                pTarget.Parent.Root = pNew;
                isNewRoot = true;
            }
            else { pNew.Prev.Next = pNew; }

            //reset the parent in case this step is coming from another job or sub job
            pNew.Parent = pTarget.Parent;
            pTarget.Prev = pNew;
            pNew.Next = pTarget;

            return isNewRoot;
        }

        //insert a task at the top of a job
        public static Step Insert(ITask pTask, Job rootJob)
        {
            Step newStep = new Step(rootJob, pTask);

            newStep.Next = rootJob.Root;
            rootJob.Root = newStep;
            if (newStep.Next != null) { newStep.Next.Prev = newStep; }
            
            return newStep;
        }

        //insert an existing step at the top of a job
        public static void Insert(Step pStep, Job rootJob)
        {
            pStep.Parent = rootJob;

            pStep.Next = rootJob.Root;
            pStep.Prev = null;
            rootJob.Root = pStep;

            if (pStep.Next != null) { pStep.Next.Prev = pStep; }
        }

        //Remove a step from the job
        //Return true if Step was the last step in the job.
        //Does not validate with the user. This is a worker class for the main UI
        //which should be doing the validation. This will do what it is told. 
        public static bool Remove(Step pStep)
        {
            bool ret = false;

            if ((pStep.Next == null) && (pStep.Prev == null))
            //This is the last remaining step in the list
            {
                
                if (pStep.Parent.Root != pStep)
                { 
                    //
                    //exception to be added. something is broke
                    //
                }
                pStep.Parent.Root = null;
                ret = true; 
            }

            //otherwise, shunt things around as needed.
            else
            {
                if (pStep.Prev == null)
                {
                    pStep.Parent.Root = pStep.Next;
                    pStep.Next.Prev = null;             
                }

                else
                {
                    pStep.Prev.Next = pStep.Next;
                    if (pStep.Next != null) { pStep.Next.Prev = pStep.Prev; }                  
                }
            }
            
            pStep.Parent = null;
            pStep.Next = null;
            pStep.Prev = null;

            return ret;
        }

        //move a step up. will not move up a layer to a parent job
        //return false if it couldn't be moved up i.e. it is already 
        //at the top.
        public static bool MoveUp(Step pStep)
        {
            Step aboveStep = pStep.Prev;
            Step bottomStep = pStep.Next;

            if (aboveStep != null)
            {
                Step topStep = aboveStep.Prev;

                if (topStep == null) { pStep.Parent.Root = pStep; }
                else { topStep.Next = pStep; }  

                pStep.Prev = topStep;
                pStep.Next = aboveStep;
                aboveStep.Prev = pStep;
                aboveStep.Next = bottomStep;
                if (bottomStep != null) { bottomStep.Prev = aboveStep; }
                
                return true;
            }
                 
            else
            //there isn't a step above to move to.
            {
                return false;
            }
        }

        //move a step up. will not move up a layer to a parent job
        //return false if it couldn't be moved up i.e. it is already 
        //at the top.
        public static bool MoveDown(Step pStep)
        {
            Step topStep = pStep.Prev;
            Step belowStep = pStep.Next;

            if (belowStep != null)
            {
                Step bottomStep = belowStep.Next;

                if (topStep == null) { pStep.Parent.Root = belowStep; }
                else { topStep.Next = belowStep; }

                pStep.Next = bottomStep;
                pStep.Prev = belowStep;             
                belowStep.Prev = topStep;
                belowStep.Next = pStep;
                if (bottomStep != null) { bottomStep.Prev = pStep; }
                
                return true;
            }

            else
            //there isn't a step below.
            {
                return false;
            }
        }
    }
}
