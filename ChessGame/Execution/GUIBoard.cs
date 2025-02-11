using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class GUIBoard : Form
    {
        private ChessGame.ChessBoard board = new ChessGame.ChessBoard();
        private Button[,] buttons = new Button[8, 8];
        private PiecePosition currPosition = null;
        public GUIBoard()
        {
            InitializeComponent();
        }
        private void GUIBoard_Load(object sender, EventArgs e)
        {
            ChessBoard board = new ChessGame.ChessBoard();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            this.ClientSize = new Size(400, 400);
            this.Text = "Chess Game";

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(50, 50),
                        Location = new Point(col * 50, row * 50),
                        BackColor = (row + col) % 2 == 0 ? Color.White : Color.Gray,
                        Tag = new PiecePosition(row, col)
                    };

                    btn.Click += OnSquareClick;
                    buttons[row, col] = btn;
                    this.Controls.Add(btn);
                }
            }

            UpdateBoardUI();
        }

        private void UpdateBoardUI()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var piece = board.GetPiece(new PiecePosition(row, col));
                    if (piece != null)
                    {
                        var image = GetPieceImage(piece);
                        buttons[row, col].Image = ResizeImage(image, 20, 40);
                    }
                    else
                    {
                        buttons[row, col].Image = null;
                    }
                }
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            var resizedImage = new Bitmap(image, new Size(width, height));
            return resizedImage;
        }


        private Image GetPieceImage(ChessGame.ChessPiece piece)
        {
            string imageName = "";
            switch (piece.Type)
            {
                case ChessGame.PieceType.Pawn:
                    imageName = piece.Color == ChessGame.PieceColor.White ? "ChessGame.Images.WhitePawn.png" : "ChessGame.Images.BlackPawn.png";
                    break;
                case ChessGame.PieceType.Knight:
                    imageName = piece.Color == ChessGame.PieceColor.White ? "ChessGame.Images.WhiteKnight.png" : "ChessGame.Images.BlackKnight.png";
                    break;
                case ChessGame.PieceType.Bishop:
                    imageName = piece.Color == ChessGame.PieceColor.White ? "ChessGame.Images.WhiteBishop.png" : "ChessGame.Images.BlackBishop.png";
                    break;
                case ChessGame.PieceType.Rook:
                    imageName = piece.Color == ChessGame.PieceColor.White ? "ChessGame.Images.WhiteRook.png" : "ChessGame.Images.BlackRook.png";
                    break;
                case ChessGame.PieceType.Queen:
                    imageName = piece.Color == ChessGame.PieceColor.White ? "ChessGame.Images.WhiteQueen.png" : "ChessGame.Images.BlackQueen.png";
                    break;
                case ChessGame.PieceType.King:
                    imageName = piece.Color == ChessGame.PieceColor.White ? "ChessGame.Images.WhiteKing.png" : "ChessGame.Images.BlackKing.png";
                    break;
                default:
                    return null;
            }

            using (var stream = GetType().Assembly.GetManifestResourceStream(imageName))
            {
                return Image.FromStream(stream);
            }
        }

        private void OnSquareClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            PiecePosition clickedPosition = (PiecePosition)clickedButton.Tag;

            if (currPosition == null)
            {
                // Select the piece to move
                if (board.GetPiece(clickedPosition) != null)
                {
                    currPosition = clickedPosition;
                    clickedButton.BackColor = Color.Yellow;
                }
            }
            else
            {
                // Move the selected piece
                if (board.MovePiece(currPosition, clickedPosition))
                {
                    UpdateBoardUI();
                }
                buttons[currPosition.Row, currPosition.Column].BackColor =
                    (currPosition.Row + currPosition.Column) % 2 == 0 ? Color.White : Color.Gray;
                currPosition = null;
            }
        }
    }
}