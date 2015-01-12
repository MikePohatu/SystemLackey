using System;
using SystemLackey.Worker;

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
            pNew.Next = pTarget.Next;

            if (pTarget.Next != null)
            {
                pNew.Next.Prev = pNew;
            }

            //reset the parent in case this step is coming from another job or sub job
            pNew.Parent = pTarget.Parent;
            pTarget.Next = pNew;
            pNew.Prev = pTarget;
        }

        //insert an existing step after the specified step
        public static void InsertAbove(Step pNew, Step pTarget)
        {
            pNew.Prev = pTarget.Prev;

            if (pTarget.Prev != null)
            {
                pNew.Prev.Next = pNew;
            }

            //reset the parent in case this step is coming from another job or sub job
            pNew.Parent = pTarget.Parent;
            pTarget.Prev = pNew;
            pNew.Next = pTarget;
        }

        //insert a new task at the top of a job
        public static Step Insert(ITask pTask, Job rootJob)
        {
            Step newStep = new Step(rootJob, pTask);
            newStep.Next = rootJob.Root;
            if (rootJob.Root != null)
            {
                rootJob.Root.Prev = newStep;    
            }
            rootJob.Root = newStep;
            return newStep;
        }

        //insert an existing step at the top of a job
        public static void Insert(Step pStep, Job rootJob)
        {
            pStep.Next = rootJob.Root;
            if (rootJob.Root != null)
            {
                rootJob.Root.Prev = pStep;
            }
            //Reset the parent in case coming from another subjob.
            pStep.Parent = rootJob;
            rootJob.Root = pStep;

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

                if (topStep != null) 
                { topStep.Next = pStep; }  
                else
                { pStep.Parent.Root = pStep; }
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

                if (topStep != null) { topStep.Next = belowStep; }
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
