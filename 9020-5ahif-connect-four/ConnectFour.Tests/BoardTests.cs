using ConnectFour.Logic;
using System;
using Xunit;

namespace ConnectFour.Tests
{
    public class BoardTests
    {
        [Fact]
        public void AddWithInvalidColumnIndex()
        {
            var b = new Board();

            Assert.Throws<ArgumentOutOfRangeException>(() => b.AddStone(7));
        }

        [Fact]
        public void PlayerChangesWhenAddingStone()
        {
            var b = new Board();

            var oldPlayer = b.Player;
            b.AddStone(0);

            // Verify that player has changed
            Assert.NotEqual(oldPlayer, b.Player);
        }

        [Fact]
        public void AddingTooManyStonesToARow()
        {
            var b = new Board();

            for(var i=0; i<6; i++)
            {
                b.AddStone(0);
            }

            var oldPlayer = b.Player;
            Assert.Throws<InvalidOperationException>(() => b.AddStone(0));
            Assert.Equal(oldPlayer, b.Player);
        }

        [Fact]
        public void BoardIsFull()
        {
            var b = new Board();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    b.AddStone((byte)i);
                }
            }
            Assert.True(b.CheckIfBoardIsFull());
        }

        [Fact]
        public void BoardIsNotFull()
        {
            var b = new Board();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    b.AddStone((byte)i);
                }
            }
            Assert.False(b.CheckIfBoardIsFull());
        }

        [Fact]
        public void PlayerWonVertical()
        {
            var b = new Board();
            for (int i = 1; i <= 4; i++)
            {
                b.AddStone(0);
                b.AddStone(1);
            }
            Assert.True(b.CheckIfOnePlayerHasWon());
        }

        [Fact]
        public void PlayerWonHoricontal()
        {
            var b = new Board();
            for (int i = 1; i <= 4; i++)
            {
                b.AddStone((byte)i);
                b.AddStone((byte)i);
            }
            Assert.True(b.CheckIfOnePlayerHasWon());
        }

        [Fact]
        public void PlayerWonDiaogonal()
        {
            var b = new Board();
            b.AddStone(0);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(3);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(3);
            b.AddStone(4);
            b.AddStone(3);
            b.AddStone(3);
            Assert.True(b.CheckIfOnePlayerHasWon());

            var b2 = new Board();
            b2.AddStone(0);
            b2.AddStone(0);
            b2.AddStone(0);
            b2.AddStone(0);
            b2.AddStone(1);
            b2.AddStone(2);
            b2.AddStone(1);
            b2.AddStone(1);
            b2.AddStone(1);
            b2.AddStone(2);
            b2.AddStone(2);
            b2.AddStone(3);

            Assert.True(b.CheckIfOnePlayerHasWon());
        }
        
        [Fact]
        public void CheckOldPlayer()
        {
            var b = new Board();
            b.AddStone(0);
            b.AddStone(2);
            int oldPlayer = b.GetOldPlayer();
            Assert.Equal(1, oldPlayer);
            b.AddStone(0);
            oldPlayer = b.GetOldPlayer();
            Assert.Equal(2, oldPlayer);
        }
    }
}
