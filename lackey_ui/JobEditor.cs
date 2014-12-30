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
            if (pPrev.Next != null)
            {
                newStep.Next = pPrev.Next;
                newStep.Next.Prev = newStep; 
            }

            pPrev.Next = newStep;
            newStep.Prev = pPrev;
            return newStep;
        }

        //insert a new task at the top of a job
        public static Step Insert(ITask pTask, Job rootJob)
        {
            Step newStep = new Step(rootJob, pTask);
            if (rootJob.Root != null)
            {
                newStep.Next = rootJob.Root;
                newStep.Next.Prev = newStep;    
            }
            rootJob.Root = newStep;
            return newStep;
        }

        //Remove a step from the job
        //Return true if Step was the last step in the job.
        //Does not validate. This is a worker class for the main UI
        //which should be doing the validation. This will do what it is told. 
        public static bool Remove(Step pStep)
        {
            bool ret = false;

            if ((pStep.Next == null) && (pStep.Prev == null))
            //This is the last remaining step in the list
            {
                
                if (pStep.Parent.Root != pStep)
                { 
                    //exception to be added. something is broke
                }
                pStep.Parent.Root = null;
                ret = true; 
            }

            //otherwise, shunt things around as needed.
            else
            {
                if (pStep.Prev != null)
                {
                    pStep.Prev.Next = pStep.Next;
                    pStep.Next.Prev = pStep.Prev;
                }

                else
                {
                    pStep.Parent.Root = pStep.Next;
                    pStep.Next.Prev = null;
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

                topStep.Next = pStep;
                pStep.Prev = topStep;
                pStep.Next = aboveStep;
                aboveStep.Prev = pStep;
                aboveStep.Next = bottomStep;
                bottomStep.Prev = aboveStep;
                return true;
            }
                 
            else
            //there isn't a step above.
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

                topStep.Next = belowStep;
                pStep.Next = bottomStep;
                pStep.Prev = belowStep;             
                belowStep.Prev = topStep;
                belowStep.Next = pStep;
                bottomStep.Prev = pStep;
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
