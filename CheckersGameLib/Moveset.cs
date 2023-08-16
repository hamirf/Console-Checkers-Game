namespace CheckersGameLib;

/// <summary>
/// Represent any moveset a piece can have
/// </summary>
public class Moveset
{
    /// <summary>
    /// Retrieve list of single move of a checkers game, whether it's for basic piece or king piece
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>List of position that include any single move</returns>
    public List<Position> SingleMove(ICheckersPiece piece)
    {
        return GetPositions(piece, 1, 1);
    }

    /// <summary>
    /// Retrieve list of single jump move of a checkers game, whether it's for basic piece or king piece
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>List of position that include any single jump move</returns>
    public List<Position> SingleJumpMove(ICheckersPiece piece)
    {
        return GetPositions(piece, 2, 2);
    }

    /// <summary>
    /// Retrieve list of double jump move of a checkers game, whether it's for basic piece or king piece
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>List of position that include any double jump move</returns>
    public List<Position> DoubleJumpMove(ICheckersPiece piece)
    {
        return GetPositions(piece, 4, 4);
    }

    /// <summary>
    /// Retrieve list of position that include single move, single jump move, and double jump move
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="rowOffset"></param>
    /// <param name="colOffset"></param>
    /// <returns>List of position of generated moveset for a piece</returns>
    private List<Position> GetPositions(ICheckersPiece piece, int rowOffset, int colOffset)
    {
        int row = piece.GetPosition().GetRow();
        int col = piece.GetPosition().GetColumn();
        List<Position> positions = new List<Position>();

        if (piece.GetRank().Equals(Rank.Basic))
        {
            if (piece.GetPieceColor().Equals(PieceColor.Black))
            {
                positions.Add(new Position(row + rowOffset, col + colOffset));
                positions.Add(new Position(row + rowOffset, col - colOffset));
                if (Math.Abs(rowOffset) == 4)
                {
                    positions.Add(new Position(row + rowOffset, col));
                }
            }
            else
            {
                positions.Add(new Position(row - rowOffset, col + colOffset));
                positions.Add(new Position(row - rowOffset, col - colOffset));
                if (Math.Abs(rowOffset) == 4)
                {
                    positions.Add(new Position(row - rowOffset, col));
                }
            }
        }
        else
        {
            positions.Add(new Position(row + rowOffset, col + colOffset));
            positions.Add(new Position(row + rowOffset, col - colOffset));
            positions.Add(new Position(row - rowOffset, col + colOffset));
            positions.Add(new Position(row - rowOffset, col - colOffset));
            if (Math.Abs(rowOffset) == 4)
            {
                positions.Add(new Position(row + rowOffset, col));
                positions.Add(new Position(row - rowOffset, col));
            }
            else if (Math.Abs(colOffset) == 4)
            {
                positions.Add(new Position(row, col + colOffset));
                positions.Add(new Position(row, col - colOffset));
            }
        }

        return positions;
    }

}