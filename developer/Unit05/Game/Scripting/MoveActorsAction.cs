using System.Collections.Generic;
using Unit05.Game.Casting;


namespace Unit05.Game.Scripting
{

    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>
public class MoveActorsAction : Action
{


        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {

        }


    // 3) Override the Execute(Cast cast, Script script) method. Use the following 
    //    method comment. You custom implementation should do the following:
    //    a) get all the actors from the cast
    //    b) loop through all the actors
    //    c) call the MoveNext() method on each actor.
    public void Execute(Cast cast, Script script)
    {

            // a) get all the actors from the cast
            List<Actor> actors = cast.GetAllActors();

            // b) loop through all the actors
            foreach (Actor uniqueActor in actors)
            {

                // c) call the MoveNext() method on each actor.
                uniqueActor.MoveNext();

                }


    }

}

}





