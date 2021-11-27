using AnkhMorporkGame.Services;

namespace AnkhMorporkGame
{
    public class UnitOfWork
    {
        public AssassinsService AssassinsService { get; }
        public ThievesGuildService ThievesGuildService { get; }
        public BeggarsService BeggarsService { get; }
        public FoolsService FoolsService { get; }

        public UnitOfWork()
        {
            AssassinsService = new AssassinsService();
            ThievesGuildService = new ThievesGuildService();
            BeggarsService = new BeggarsService();
            FoolsService = new FoolsService();
        }
    }
}
