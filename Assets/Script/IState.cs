

public interface IState 
{
   void Enter(FSM machine);

   void Execute();

   void Exit();
}
