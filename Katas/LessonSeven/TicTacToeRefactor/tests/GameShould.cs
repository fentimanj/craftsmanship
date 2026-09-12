namespace tests
{
    using src;

    public class GameShould
    {
        private Game game;

        public GameShould()
        {
           this.game = new Game();
        }

        [Fact]
        public void NotAllowPlayerOToPlayFirst()
        {
            Action wrongPlay = () => this.game.Play('O', 0, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            this.game.Play('X', 0, 0);
            
            Action wrongPlay = () => this.game.Play('X', 1, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            this.game.Play('X', 0, 0);

            Action wrongPlay = () => this.game.Play('O', 0, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            this.game.Play('X', 0, 0);
            this.game.Play('O', 1, 0);

            Action wrongPlay = () => this.game.Play('X', 0, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            this.game.Play('X', 0, 0);
            this.game.Play('O', 1, 0);
            this.game.Play('X', 0, 1);
            this.game.Play('O', 1, 1);
            this.game.Play('X', 0, 2);

            var winner = this.game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            this.game.Play('X', 2, 2);
            this.game.Play('O', 0, 0);
            this.game.Play('X', 1, 0);
            this.game.Play('O', 0, 1);
            this.game.Play('X', 1, 1);
            this.game.Play('O', 0, 2);

            var winner = this.game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            this.game.Play('X', 1, 0);
            this.game.Play('O', 0, 0);
            this.game.Play('X', 1, 1);
            this.game.Play('O', 0, 1);
            this.game.Play('X', 1, 2);

            var winner = this.game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            this.game.Play('X', 0, 0);
            this.game.Play('O', 1, 0);
            this.game.Play('X', 2, 0);
            this.game.Play('O', 1, 1);
            this.game.Play('X', 2, 1);
            this.game.Play('O', 1, 2);

            var winner = this.game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            this.game.Play('X', 2, 0);
            this.game.Play('O', 0, 0);
            this.game.Play('X', 2, 1);
            this.game.Play('O', 0, 1);
            this.game.Play('X', 2, 2);

            var winner = this.game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            this.game.Play('X', 0, 0);
            this.game.Play('O', 2, 0);
            this.game.Play('X', 1, 0);
            this.game.Play('O', 2, 1);
            this.game.Play('X', 1, 1);
            this.game.Play('O', 2, 2);

            var winner = this.game.Winner();

            Assert.Equal('O', winner);
        }
    }
}
