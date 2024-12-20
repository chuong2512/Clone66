using System;

namespace ICEBOOO
{
    public static class AvailablePieces
    {
        public static Piece[] All()
        {
            return new Piece[]
            {
                OPiece(),
                TPiece(),
                SPiece(),
                ZPiece(),
                JPiece(),
                LPiece(),
                IPiece()
            };
        }

        public static Piece OPiece()
        {
            var positions = new Position[]
            {
                new Position(0, 0),
                new Position(1, 0),
                new Position(1, 1),
                new Position(0, 1)
            };
            return new Piece(positions, PieceType.O, false);
        }

        private static Piece TPiece()
        {
            var positions = new Position[]
            {
                new Position(0, 0),
                new Position(1, 0),
                new Position(-1, 0),
                new Position(0, 1)
            };
            return new Piece(positions, PieceType.T);
        }

        private static Piece SPiece()
        {
            var positions = new Position[]
            {
                new Position(0, 0),
                new Position(1, 0),
                new Position(0, 1),
                new Position(-1, 1)
            };
            return new Piece(positions, PieceType.S);
        }

        public static Piece ZPiece()
        {
            var positions = new Position[]
            {
                new Position(0, 0),
                new Position(-1, 0),
                new Position(0, 1),
                new Position(1, 1)
            };
            return new Piece(positions, PieceType.Z);
        }

        public static Piece JPiece()
        {
            var positions = new Position[]
            {
                new Position(0, 0),
                new Position(1, 0),
                new Position(-1, 0),
                new Position(-1, -1)
            };
            return new Piece(positions, PieceType.J);
        }

        private static Piece LPiece()
        {
            var positions = new Position[]
            {
                new Position(0, 0),
                new Position(1, 0),
                new Position(-1, 0),
                new Position(-1, 1)
            };
            return new Piece(positions, PieceType.L);
        }

        private static Piece IPiece()
        {
            var positions = new Position[]
            {
                new Position(0, 0),
                new Position(1, 0),
                new Position(-1, 0),
                new Position(-2, 0)
            };
            return new Piece(positions, PieceType.I);
        }
    }
}