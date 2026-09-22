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
            Action wrongPlay = () =>
            {
                Symbol symbol = 'O'.ToSymbol();
                var position = PositionMapper.Map(0, 0);
        
                this.game.Play(symbol, position);
            };

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol, position);

            Action wrongPlay = () =>
            {
                Symbol symbol1 = 'X'.ToSymbol();
                var position1 = PositionMapper.Map(1, 0);
        
                this.game.Play(symbol1, position1);
            };

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol, position);

            Action wrongPlay = () =>
            {
                Symbol symbol1 = 'O'.ToSymbol();
                var position1 = PositionMapper.Map(0, 0);
        
                this.game.Play(symbol1, position1);
            };

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol, position);
            Symbol symbol1 = 'O'.ToSymbol();
            var position1 = PositionMapper.Map(1, 0);
        
            this.game.Play(symbol1, position1);

            Action wrongPlay = () =>
            {
                Symbol symbol2 = 'X'.ToSymbol();
                var position2 = PositionMapper.Map(0, 0);
        
                this.game.Play(symbol2, position2);
            };

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol, position);
            Symbol symbol1 = 'O'.ToSymbol();
            var position1 = PositionMapper.Map(1, 0);
        
            this.game.Play(symbol1, position1);
            Symbol symbol2 = 'X'.ToSymbol();
            var position2 = PositionMapper.Map(0, 1);
        
            this.game.Play(symbol2, position2);
            Symbol symbol3 = 'O'.ToSymbol();
            var position3 = PositionMapper.Map(1, 1);
        
            this.game.Play(symbol3, position3);
            Symbol symbol4 = 'X'.ToSymbol();
            var position4 = PositionMapper.Map(0, 2);
        
            this.game.Play(symbol4, position4);

            var winner = this.game.Winner().ToChar();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(2, 2);
        
            this.game.Play(symbol, position);
            Symbol symbol1 = 'O'.ToSymbol();
            var position1 = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol1, position1);
            Symbol symbol2 = 'X'.ToSymbol();
            var position2 = PositionMapper.Map(1, 0);
        
            this.game.Play(symbol2, position2);
            Symbol symbol3 = 'O'.ToSymbol();
            var position3 = PositionMapper.Map(0, 1);
        
            this.game.Play(symbol3, position3);
            Symbol symbol4 = 'X'.ToSymbol();
            var position4 = PositionMapper.Map(1, 1);
        
            this.game.Play(symbol4, position4);
            Symbol symbol5 = 'O'.ToSymbol();
            var position5 = PositionMapper.Map(0, 2);
        
            this.game.Play(symbol5, position5);

            var winner = this.game.Winner().ToChar();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(1, 0);
        
            this.game.Play(symbol, position);
            Symbol symbol1 = 'O'.ToSymbol();
            var position1 = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol1, position1);
            Symbol symbol2 = 'X'.ToSymbol();
            var position2 = PositionMapper.Map(1, 1);
        
            this.game.Play(symbol2, position2);
            Symbol symbol3 = 'O'.ToSymbol();
            var position3 = PositionMapper.Map(0, 1);
        
            this.game.Play(symbol3, position3);
            Symbol symbol4 = 'X'.ToSymbol();
            var position4 = PositionMapper.Map(1, 2);
        
            this.game.Play(symbol4, position4);

            var winner = this.game.Winner().ToChar();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol, position);
            Symbol symbol1 = 'O'.ToSymbol();
            var position1 = PositionMapper.Map(1, 0);
        
            this.game.Play(symbol1, position1);
            Symbol symbol2 = 'X'.ToSymbol();
            var position2 = PositionMapper.Map(2, 0);
        
            this.game.Play(symbol2, position2);
            Symbol symbol3 = 'O'.ToSymbol();
            var position3 = PositionMapper.Map(1, 1);
        
            this.game.Play(symbol3, position3);
            Symbol symbol4 = 'X'.ToSymbol();
            var position4 = PositionMapper.Map(2, 1);
        
            this.game.Play(symbol4, position4);
            Symbol symbol5 = 'O'.ToSymbol();
            var position5 = PositionMapper.Map(1, 2);
        
            this.game.Play(symbol5, position5);

            var winner = this.game.Winner().ToChar();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(2, 0);
        
            this.game.Play(symbol, position);
            Symbol symbol1 = 'O'.ToSymbol();
            var position1 = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol1, position1);
            Symbol symbol2 = 'X'.ToSymbol();
            var position2 = PositionMapper.Map(2, 1);
        
            this.game.Play(symbol2, position2);
            Symbol symbol3 = 'O'.ToSymbol();
            var position3 = PositionMapper.Map(0, 1);
        
            this.game.Play(symbol3, position3);
            Symbol symbol4 = 'X'.ToSymbol();
            var position4 = PositionMapper.Map(2, 2);
        
            this.game.Play(symbol4, position4);

            var winner = this.game.Winner().ToChar();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            Symbol symbol = 'X'.ToSymbol();
            var position = PositionMapper.Map(0, 0);
        
            this.game.Play(symbol, position);
            Symbol symbol1 = 'O'.ToSymbol();
            var position1 = PositionMapper.Map(2, 0);
        
            this.game.Play(symbol1, position1);
            Symbol symbol2 = 'X'.ToSymbol();
            var position2 = PositionMapper.Map(1, 0);
        
            this.game.Play(symbol2, position2);
            Symbol symbol3 = 'O'.ToSymbol();
            var position3 = PositionMapper.Map(2, 1);
        
            this.game.Play(symbol3, position3);
            Symbol symbol4 = 'X'.ToSymbol();
            var position4 = PositionMapper.Map(1, 1);
        
            this.game.Play(symbol4, position4);
            Symbol symbol5 = 'O'.ToSymbol();
            var position5 = PositionMapper.Map(2, 2);
        
            this.game.Play(symbol5, position5);

            var winner = this.game.Winner().ToChar();

            Assert.Equal('O', winner);
        }
    }
}
