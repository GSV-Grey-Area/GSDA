using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MySqlConnector;

namespace Pokemon
{
	[Serializable]
	public class IO
	// Input and output class.
	{
		public void Write(string echo)
		// Writes.
		{
			Console.Write(echo);
		}

		public void WriteLine(string echo)
		// Writes a line.
		{
			Console.WriteLine(echo);
		}

		public void Dialogue(string dialogue)
		// Generates text character by character.
		{
			for (int i = 0; i < dialogue.Length; i++)
			// Moves, character by character, from the first character of a string to the last.
			{
				Console.Write(dialogue[i]); // Prints the n-th character.
				Thread.Sleep(25); // Waits a hundred milliseconds.
			}
		}

		public string ReadLine()
		// Reads a line.
		{
			return Console.ReadLine();
		}

		public void WindowResize(int a, int b)
		{
			Console.SetWindowSize(a, b);
			return;
		}

		public string Padder(string input, int length)
		{
			string output = "";
			int inputLength = input.Length;
			for (int i = inputLength; i < length; i++)
			{
				input = input + " ";
			}
			output = input;
			return output;
		}

		public string Liner(int length)
		{
			string line = "";
			for (int i = 0; i < length; i++)
			{
				line = line + "-";
			}
			return line;
		}

		public Point[,,] BigFill(int x1, int y1, int x2, int y2, int a, int b, Point[,,] array)
		// "Paints" rectangles. Takes the coordinates of the lower left and upper right corners.
		// x1: X of the lower left point.
		// y1: Y of the lower left point.
		// x2: X of the upper right point.
		// y2: Y of the upper right point.
		// a: Background color.
		// b: Foreground color.
		// array: Canvas.
		// colors: Color list.
		{
			for (int i = x1; i < x2; i++)
			{
				for (int j = y1; j < y2; j++)
				{
					array[i, j, 1].Fill(colors[a], colors[b], true); // Paints each point with the received color data.
				}
			}
			return array; // Returns the modified canvas.
		}

		public Point[,,] Circumference(int a, int b, int r, Point[,,] array)
		// Draws a circumference using its center, its radius, and its position.
		{
			int posX1 = a - r; // Left point.
			int posY1 = b; // Height of the equatorial points, repeated as possibly outdated legacy from a line-drawing function.
			int posX2 = a + r; // Right point.
			int posY2 = b;

			float difX = r * 2; // Width (diameter).
			float difY = 0;

			if (difX != 0)
			{
				float slope = difY / difX; // Possibly obsolete.
				int posX = posX1;
				int posY = posX1 * ((int)slope);
				if (posX2 > posX1)
				{
					for (int p = posX; p <= posX2; p++)
					// Calculates the height of the curve at each point between the equatorial.
					{
						posX = p;
						// Upper curve:
						posY = (int)((Math.Sqrt(r * r - (posX - a) * (posX - a))) + b);
						if (!(posX < 0) && !(posX > (array.GetLength(0) - 1)) && !(posY < 0) && !(posY > (array.GetLength(1) - 1)))
						{
							array[posX, posY, 1].Fill(colors[11], colors[11], true);
						}
						// Lower curve:
						posY = (int)(-(Math.Sqrt((r * r) - (posX - a) * (posX - a))) + b);
						if (!(posX < 0) && !(posX > (array.GetLength(0) - 1)) && !(posY < 0) && !(posY > (array.GetLength(1) - 1)))
						{
							array[posX, posY, 1].Fill(colors[11], colors[11], true);
						}
					}
				}
			}
			return array;
		}

		int[] colors = new int[17];
		public void ColorTransfer(int[] colors)
		{
			this.colors = colors;
			return;
		}

		public Point[,,] ColorLoad(int c, int x, int y, Point[,,] array, Array[] graphics)//Carga imágenes en color
		{
			int a = x; // Position of the upper left corner.
			int b = y;
			string[,] image3 = (string[,])graphics[c]; // Copies the desired image.
													   // Generates a matrix with dimensions "opposite" to those of the previous matrix.
			string[,] image4 = new string[graphics[c].GetLength(1), graphics[c].GetLength(0)];
			// Transposition and data transfer from one matrix to the other:
			for (int j = 0; j < image3.GetLength(1); j++)
			{
				for (int i = 0; i < image3.GetLength(0); i++)
				{
					image4[j, i] = image3[i, j];
				}
			}

			for (int j = 0; j < image4.GetLength(1); j++)
			// If a point in the image is not empty, its content will be rendered.
			{
				for (int i = 0; i < image4.GetLength(0); i++)
				{
					if (
						(i + a) >= 0 &&
						(i + a) < array.GetLength(0) &&
						(b - j) >= 0 &&
						(b - j) < array.GetLength(1) &&
						image4[i, j] != "  "
					)
					{
						// The images are coded in characters, and their values are transformed according to a modified color list.
						array[i + a, b - j, 1].Fill(colors[(int)image4[i, j][0] - 48], colors[(int)image4[i, j][1] - 48], true); //Pinta
					}
				}
			}
			return array;
		}

		public Point[,,] LoadText(int x, int y, Point[,,] array, string text)
		// Text loader.
		{
			for (int i = 0; i < text.Length; i += 2)
			// Advances two units in each step, to move from "pixel" to "pixel".
			{
				if
				(
					// Determines whether the next character will fit in the canvas or not. I think.
					(x + (i / 2)) < (array.GetLength(0)) &&
					(x) != array.GetLength(0)
				)
				{
					// Sets the left character in the canvas.
					array[x + (i / 2), y, 1].SetContentA(text[i]);
					array[x + (i / 2), y, 1].SetRender(true);
					if ((i + 1) < text.Length)
					// Determines whether the second character will fit.
					{
						// Sets the right character in the canvas.
						array[x + (i / 2), y, 1].SetContentB(text[i + 1]);
					}
				}
			}
			return array;
		}

		public Point[,,] LoadBig(int c, int x, int y, Point[,,] array, Array[] graphics)
		// Big loader.
		// "Jumps" the "pixels" in steps of two, and in each position draws a big point.
		{
			int a = x;
			int b = y;
			string[,] image3 = (string[,])graphics[c];
			string[,] image4 = new string[graphics[c].GetLength(1), graphics[c].GetLength(0)];
			for (int j = 0; j < image3.GetLength(1); j++)
			{
				for (int i = 0; i < image3.GetLength(0); i++)
				{
					image4[j, i] = image3[i, j];
				}
			}

			for (int j = 0; j < image4.GetLength(1); j += 1)
			{
				for (int i = 0; i < image4.GetLength(0); i += 1)
				{
					if
					(
						(i * 2 + a) > -1 &&
						(i * 2 + a) < array.GetLength(0) &&
						(b - j * 2) > -1 &&
						(b - j * 2) < array.GetLength(1) &&
						image4[i, j] != "  "
					)
					{
						array[i * 2 + a, b - j * 2, 1].Fill(colors[(int)image4[i, j][0] - 48], colors[(int)image4[i, j][1] - 48], true);
						array[i * 2 + a, b - j * 2 + 1, 1].Fill(colors[(int)image4[i, j][0] - 48], colors[(int)image4[i, j][1] - 48], true);
						if
						(
							(i * 2 + a + 1) >= 0 &&
							(i * 2 + a + 1) < array.GetLength(0)
						)
						{
							array[i * 2 + a + 1, b - j * 2, 1].Fill(colors[(int)image4[i, j][0] - 48], colors[(int)image4[i, j][1] - 48], true);
							array[i * 2 + a + 1, b - j * 2 + 1, 1].Fill(colors[(int)image4[i, j][0] - 48], colors[(int)image4[i, j][1] - 48], true);
						}
					}
				}
			}
			return array;
		}

		public Point[,,] BMPLoader(int imageCode, int x, int y, Point[,,] array)
		{
			int a = x;
			int b = y;

		a:
			// io.WriteLine();
			// io.WriteLine("¿Qué imagen cargar?");

			//int selector = int.Parse(io.ReadLine());
			int selector = imageCode;

			int selector1;
			if (imageCode < 100)
			{
				selector1 = 0;
			}
			else
			{
				selector1 = selector / 100;
			}

			int selector2;
			if (imageCode < 10)
			{
				selector2 = 0;
			}
			else
			{
				selector2 = (selector - selector1 * 100) / 10;
			}

			int selector3;
			if (imageCode < 1)
			{
				selector3 = 0;
			}
			else
			{
				selector3 = (selector - selector1 * 100) - selector2 * 10;
			}

			if (!File.Exists("..\\..\\..\\img\\" + selector1 + "" + selector2 + "" + selector3 + ".bmp"))
			{
				// io.WriteLine("No existe.");
				goto a;
			}

			byte[] readText = File.ReadAllBytes("..\\..\\..\\img\\" + selector1 + "" + selector2 + "" + selector3 + ".bmp");

			int size = readText[2] + readText[3] * 256 + readText[4] * 256 * 256 + readText[5] * 256 * 256 * 256;
			int offset = readText[10] + readText[11] * 256 + readText[12] * 256 * 256 + readText[13] * 256 * 256 * 256;
			int header = readText[14] + readText[15] * 256 + readText[16] * 256 * 256 + readText[17] * 256 * 256 * 256;
			int width = readText[18] + readText[19] * 256 + readText[20] * 256 * 256 + readText[21] * 256 * 256 * 256;
			int height = readText[22] + readText[23] * 256 + readText[24] * 256 * 256 + readText[25] * 256 * 256 * 256;
			int bitsPerPixel = readText[28] + readText[29] * 256;
			int imageSize = readText[34] + readText[35] * 256 + readText[36] * 256 * 256 + readText[37] * 256 * 256 * 256;

			// WriteLine("" + width);
			// WriteLine("" + height);

			int[,] transfer = new int[width, height];
			int[] buffer = new int[3];
			int[] buffer2 = new int[16];
			x = 0;
			for (int d = offset; d < size; d = d + width * 3, x = x + 1)
			{
				for (int e = 0; e < width * 3; e = e + 3)
				{
					for (int f = 0; f < 3; f++)
					{
						buffer[f] = readText[d + e + f];
					}
					transfer[e / 3, x] = buffer[0] * 1000000 + buffer[1] * 1000 + buffer[2];
				}
			}

			int[,] transferB = new int[transfer.GetLength(1), transfer.GetLength(0)]; // Genera una matriz de dimensiones opuestas
			for (int j = 0; j < transfer.GetLength(1); j++) // Transposición y volcado de una matriz a la otra
			{
				for (int i = 0; i < transfer.GetLength(0); i++)
				{
					transferB[j, i] = transfer[i, j];
				}
			}

			int[,] transferC = new int[transferB.GetLength(0), transferB.GetLength(1)]; // Genera una matriz con las mismas dimensiones
			for (int j = transferC.GetLength(1) - 1; j >= 0; j--) // Reflexión vertical y volcado de una matriz a la otra
			{
				for (int i = 0; i < transferC.GetLength(0); i++)
				{
					transferC[transferC.GetLength(0) - 1 - i, j] = transferB[i, j];
				}
			}

			for (int jr = 0; jr < transferC.GetLength(1); jr++)
			{
				for (int ir = 0; ir < transferC.GetLength(0); ir++)
				{
					if (
						(ir + a) > -1 &&
						(ir + a) < array.GetLength(0) &&
						(b - jr) > -1 &&
						(b - jr) < array.GetLength(1) &&
						Codex(transferC[jr, ir]) != "  "
					)
					{
						array[ir + a, b - jr, 1].Fill(colors[(int)Codex(transferC[jr, ir])[0] - 48], colors[(int)Codex(transferC[jr, ir])[1] - 48], true);
						array[ir + a, b - jr, 1].Fill(colors[(int)Codex(transferC[jr, ir])[0] - 48], colors[(int)Codex(transferC[jr, ir])[1] - 48], true);
					}
				}
			}
			return array;
		}

		public string Codex(int number)
		{
			string code = "";
			switch (number)
			{
				case 12012012: code = "00"; break;
				case 52051053: code = "01"; break;
				case 83086086: code = "02"; break;
				case 98101101: code = "03"; break;
				case 16013083: code = "04"; break;
				case 37033099: code = "05"; break;
				case 64015060: code = "06"; break;
				case 66010077: code = "07"; break;
				case 89026010: code = "08"; break;
				case 107052028: code = "09"; break;
				case 93064028: code = "0:"; break;
				case 91092042: code = "0;"; break;
				case 13067014: code = "0<"; break;
				case 12083014: code = "0="; break;
				case 11067081: code = "0>"; break;
				case 69103108: code = "0?"; break;
				case 98099099: code = "10"; break;
				case 118118118: code = "11"; break;
				case 142143143: code = "12"; break;
				case 153154154: code = "13"; break;
				case 101099140: code = "14"; break;
				case 111108151: code = "15"; break;
				case 126102122: code = "16"; break;
				case 128099135: code = "17"; break;
				case 146105099: code = "18"; break;
				case 158119106: code = "19"; break;
				case 146125106: code = "1:"; break;
				case 144145114: code = "1;"; break;
				case 99129101: code = "1<"; break;
				case 99139101: code = "1="; break;
				case 98128139: code = "1>"; break;
				case 130153156: code = "1?"; break;
				case 169171170: code = "20"; break;
				case 186186186: code = "21"; break;
				case 204204204: code = "22"; break;
				case 213213213: code = "23"; break;
				case 172170203: code = "24"; break;
				case 180178211: code = "25"; break;
				case 192172189: code = "26"; break;
				case 194170199: code = "27"; break;
				case 207179173: code = "28"; break;
				case 217186176: code = "29"; break;
				case 208192177: code = "2:"; break;
				case 207207183: code = "2;"; break;
				case 172194173: code = "2<"; break;
				case 171203173: code = "2="; break;
				case 170193202: code = "2>"; break;
				case 196212216: code = "2?"; break;
				case 201202202: code = "30"; break;
				case 217217217: code = "31"; break;
				case 233233233: code = "32"; break;
				case 242242242: code = "33"; break;
				case 205205232: code = "34"; break;
				case 212210239: code = "35"; break;
				case 223204220: code = "36"; break;
				case 224202228: code = "37"; break;
				case 237208203: code = "38"; break;
				case 246216206: code = "39"; break;
				case 238223208: code = "3:"; break;
				case 236236213: code = "3;"; break;
				case 202224204: code = "3<"; break;
				case 203231206: code = "3="; break;
				case 202224231: code = "3>"; break;
				case 226242244: code = "3?"; break;
				case 28014166: code = "40"; break;
				case 58052181: code = "41"; break;
				case 94090199: code = "42"; break;
				case 106104209: code = "43"; break;
				case 31015197: code = "44"; break;
				case 48034205: code = "45"; break;
				case 73018184: code = "46"; break;
				case 74012193: code = "47"; break;
				case 96028165: code = "48"; break;
				case 109052172: code = "49"; break;
				case 100066171: code = "4:"; break;
				case 94091177: code = "4;"; break;
				case 27067167: code = "4<"; break;
				case 27083167: code = "4="; break;
				case 25068196: code = "4>"; break;
				case 77106211: code = "4?"; break;
				case 72061193: code = "50"; break;
				case 94084208: code = "51"; break;
				case 121114225: code = "52"; break;
				case 135127234: code = "53"; break;
				case 75061224: code = "54"; break;
				case 86072231: code = "55"; break;
				case 105062209: code = "56"; break;
				case 106060220: code = "57"; break;
				case 124068192: code = "58"; break;
				case 140086198: code = "59"; break;
				case 127095199: code = "5:"; break;
				case 124119205: code = "5;"; break;
				case 72099194: code = "5<"; break;
				case 73109197: code = "5="; break;
				case 71096222: code = "5>"; break;
				case 108126236: code = "5?"; break;
				case 127021114: code = "60"; break;
				case 145056132: code = "61"; break;
				case 166090155: code = "62"; break;
				case 178106166: code = "63"; break;
				case 127022155: code = "64"; break;
				case 139037161: code = "65"; break;
				case 152023136: code = "66"; break;
				case 154020146: code = "67"; break;
				case 169031114: code = "68"; break;
				case 182058120: code = "69"; break;
				case 169065121: code = "6:"; break;
				case 168094127: code = "6;"; break;
				case 127074114: code = "6<"; break;
				case 127086115: code = "6="; break;
				case 127070151: code = "6>"; break;
				case 156103166: code = "6?"; break;
				case 132005151: code = "70"; break;
				case 150046168: code = "71"; break;
				case 169083186: code = "72"; break;
				case 183103198: code = "73"; break;
				case 133006185: code = "74"; break;
				case 143028192: code = "75"; break;
				case 158005172: code = "76"; break;
				case 158000180: code = "77"; break;
				case 175021149: code = "78"; break;
				case 184047158: code = "79"; break;
				case 173060158: code = "7:"; break;
				case 172086165: code = "7;"; break;
				case 132064153: code = "7<"; break;
				case 133081154: code = "7="; break;
				case 131064184: code = "7>"; break;
				case 159102199: code = "7?"; break;
				case 187049004: code = "80"; break;
				case 196074048: code = "81"; break;
				case 215102082: code = "82"; break;
				case 224120102: code = "83"; break;
				case 186048080: code = "84"; break;
				case 192060094: code = "85"; break;
				case 204049055: code = "86"; break;
				case 206048073: code = "87"; break;
				case 218055001: code = "88"; break;
				case 228074023: code = "89"; break;
				case 219085022: code = "8:"; break;
				case 218109039: code = "8;"; break;
				case 181089005: code = "8<"; break;
				case 183101006: code = "8="; break;
				case 183086078: code = "8>"; break;
				case 205120106: code = "8?"; break;
				case 212101051: code = "90"; break;
				case 227120076: code = "91"; break;
				case 244144106: code = "92"; break;
				case 252155120: code = "93"; break;
				case 212101105: code = "94"; break;
				case 223110114: code = "95"; break;
				case 232102083: code = "96"; break;
				case 233099099: code = "97"; break;
				case 247108050: code = "98"; break;
				case 255120059: code = "99"; break;
				case 247128059: code = "9:"; break;
				case 246146070: code = "9;"; break;
				case 216130052: code = "9<"; break;
				case 213141052: code = "9="; break;
				case 216129099: code = "9>"; break;
				case 235156124: code = "9?"; break;
				case 186125050: code = ":0"; break;
				case 200143075: code = ":1"; break;
				case 218164103: code = ":2"; break;
				case 227176121: code = ":3"; break;
				case 188127102: code = ":4"; break;
				case 194135115: code = ":5"; break;
				case 206127083: code = ":6"; break;
				case 207124098: code = ":7"; break;
				case 221131049: code = ":8"; break;
				case 230143059: code = ":9"; break;
				case 221150058: code = "::"; break;
				case 220166069: code = ":;"; break;
				case 188153052: code = ":<"; break;
				case 184163051: code = ":="; break;
				case 185152099: code = ":>"; break;
				case 208176124: code = ":?"; break;
				case 177178081: code = ";0"; break;
				case 195194103: code = ";1"; break;
				case 212212130: code = ";2"; break;
				case 221221143: code = ";3"; break;
				case 182181124: code = ";4"; break;
				case 190189135: code = ";5"; break;
				case 200179108: code = ";6"; break;
				case 202178121: code = ";7"; break;
				case 215185081: code = ";8"; break;
				case 225194089: code = ";9"; break;
				case 216200089: code = ";:"; break;
				case 214214097: code = ";;"; break;
				case 182204083: code = ";<"; break;
				case 177211082: code = ";="; break;
				case 176201127: code = ";>"; break;
				case 203221144: code = ";?"; break;
				case 15135018: code = "<0"; break;
				case 51152053: code = "<1"; break;
				case 86172089: code = "<2"; break;
				case 99182103: code = "<3"; break;
				case 21137084: code = "<4"; break;
				case 39142101: code = "<5"; break;
				case 64136061: code = "<6"; break;
				case 67133080: code = "<7"; break;
				case 90142016: code = "<8"; break;
				case 106152030: code = "<9"; break;
				case 93159030: code = "<:"; break;
				case 95176047: code = "<;"; break;
				case 14161019: code = "<<"; break;
				case 14170020: code = "<="; break;
				case 12160086: code = "<>"; break;
				case 71183111: code = "<?"; break;
				case 12167020: code = "=0"; break;
				case 50181054: code = "=1"; break;
				case 86200091: code = "=2"; break;
				case 101209106: code = "=3"; break;
				case 19168086: code = "=4"; break;
				case 36174099: code = "=5"; break;
				case 65166064: code = "=6"; break;
				case 66165081: code = "=7"; break;
				case 93169018: code = "=8"; break;
				case 103183033: code = "=9"; break;
				case 94187033: code = "=:"; break;
				case 92203048: code = "=;"; break;
				case 13190021: code = "=<"; break;
				case 13198021: code = "=="; break;
				case 11189083: code = "=>"; break;
				case 67209106: code = "=?"; break;
				case 4131161: code = ">0"; break;
				case 46148178: code = ">1"; break;
				case 83169196: code = ">2"; break;
				case 100180206: code = ">3"; break;
				case 12130194: code = ">4"; break;
				case 34138204: code = ">5"; break;
				case 62131180: code = ">6"; break;
				case 65129190: code = ">7"; break;
				case 87135161: code = ">8"; break;
				case 105148166: code = ">9"; break;
				case 91155166: code = ">:"; break;
				case 88172173: code = ">;"; break;
				case 5157163: code = "><"; break;
				case 4166165: code = ">="; break;
				case 156193: code = ">>"; break;
				case 66180209: code = ">?"; break;
				case 139205211: code = "?0"; break;
				case 154215221: code = "?1"; break;
				case 175233238: code = "?2"; break;
				case 184242248: code = "?3"; break;
				case 141205238: code = "?4"; break;
				case 149209245: code = "?5"; break;
				case 161203226: code = "?6"; break;
				case 164199234: code = "?7"; break;
				case 179207209: code = "?8"; break;
				case 189216213: code = "?9"; break;
				case 180221212: code = "?:"; break;
				case 177236221: code = "?;"; break;
				case 139224211: code = "?<"; break;
				case 139231212: code = "?="; break;
				case 136222237: code = "?>"; break;
				case 165241249: code = "??"; break;
				default: code = "  "; break;
			}
			return code;
		}

		public Point[,,] Render(Point[,,] array)
		// Renders the so far invisible canvas.
		// To do: Multi-layer rendering.
		{
			Console.WriteLine();
			for (int j = (array.GetLength(1) - 1); j >= 0; j--)
			// Rows are rendered from the last, as the canvas is upside down.
			{
				Console.Write(" ");
				for (int i = 0; i < (array.GetLength(0)); i++)
				// n-th column-cell in the row.
				{
					if ((array[i, j, 1].GetRender()) == true)
					// If a point is to be rendered.
					{
						// Gets the colors and contents of each cell:
						Console.ForegroundColor = (ConsoleColor)array[i, j, 1].GetColor2();
						Console.BackgroundColor = (ConsoleColor)array[i, j, 1].GetColor();
						Console.Write(array[i, j, 1].GetContentA());
						Console.Write(array[i, j, 1].GetContentB());
						Console.ResetColor();
					}
					else
					// If it is not to be rendered, the point will be filled with the background color.
					{
						Console.ForegroundColor = (ConsoleColor)array[i, j, 0].GetColor2();
						Console.BackgroundColor = (ConsoleColor)array[i, j, 0].GetColor();
						Console.Write(array[i, j, 0].GetContentA());
						Console.Write(array[i, j, 0].GetContentB());
						Console.ResetColor();
					}
				}
				Console.WriteLine();
			}
			return array;
		}

		public Point[,,] Clean(Point[,,] array)
		// Empties the canvas.
		{
			for (int j = 0; j < (array.GetLength(1)); j++)
			{
				for (int i = 0; i < (array.GetLength(0)); i++)
				{
					array[i, j, 1].Fill(0, 0, false);
					array[i, j, 1].SetContentA((char)9618);
					array[i, j, 1].SetContentB((char)9618);
				}
			}
			return array;
		}

		public void Save(Player p, string path)
		{
			Player x = p;
			try
			{
				FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(filestream, x);
				filestream.Close();
			}
			catch (System.IO.IOException e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public Player Load(string path)
		{
			try
			{
				FileStream filestream2 = new FileStream(path, FileMode.Open);
				BinaryFormatter bf = new BinaryFormatter();
				object o = (Player)bf.Deserialize(filestream2);
				Player p = (Player)o;
				filestream2.Close();
				return p;
			}
			catch (System.IO.IOException e)
			{
				Console.WriteLine(e.Message);
			}
			return null;
		}

		public Species[] DataLoaderSpecies()
		{
			MySqlConnection con;
			con = new MySqlConnection("server=127.0.0.1; database=prueba4; Uid=root; password=root; port=3306"); // pwd=root;

			///////////////////////////////////////////
			con.Open();

			MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM species", con);
			MySqlDataReader r = query.ExecuteReader();

			int x = 0;
			int i = 0;

			while (r.Read())
			{
				x = r.GetInt32(0);
				++i;
			}

			con.Close();
			///////////////////////////////////////////

			Species[] species = new Species[x];

			///////////////////////////////////////////
			con.Open();

			query = new MySqlCommand("SELECT * FROM species", con);
			r = query.ExecuteReader();
			i = 0;
			while (r.Read())
			{
				int number;
				string name;
				int capRatio;
				float sexRatio;
				int bhp;
				string color;
				int atk;
				int def;
				int atkS;
				int defS;
				int speed;
				float weight;
				float height;

				number = r.GetInt32(0);
				name = r.GetString(1);
				capRatio = r.GetInt32(2);
				sexRatio = r.GetFloat(3);
				bhp = r.GetInt32(4);
				color = r.GetString(5);
				atk = r.GetInt32(6);
				def = r.GetInt32(7);
				atkS = r.GetInt32(8);
				defS = r.GetInt32(9);
				speed = r.GetInt32(10);
				weight = r.GetFloat(11);
				height = r.GetFloat(12);

				species[i] = new Species(name, capRatio, sexRatio, bhp, color, atk, def, atkS, defS, speed, weight, height);

				++i;
			}

			con.Close();
			///////////////////////////////////////////
			
			return species;
		}

		public int[] DataLoaderColors()
		{
			MySqlConnection con;
			con = new MySqlConnection("server=127.0.0.1; database=prueba4; Uid=root; password=root; port=3306"); // pwd=root;

			///////////////////////////////////////////
			con.Open();

			MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM colors", con);
			MySqlDataReader r = query.ExecuteReader();

			int x = 0;
			int i = 0;

			while (r.Read())
			{
				x = r.GetInt32(0);
				++i;
			}

			con.Close();
			///////////////////////////////////////////

			int[] colors = new int[x];

			///////////////////////////////////////////
			con.Open();

			query = new MySqlCommand("SELECT * FROM colors", con);
			r = query.ExecuteReader();
			i = 0;
			while (r.Read())
			{
				int number;
				number = r.GetInt32(1);
				colors[i] = number;
				i++;
			}

			con.Close();
			///////////////////////////////////////////

			return colors;
		}

		public Medicine[] DataLoaderMedicine()
		{
			MySqlConnection con;
			con = new MySqlConnection("server=127.0.0.1; database=prueba4; Uid=root; password=root; port=3306"); // pwd=root;

			///////////////////////////////////////////
			con.Open();

			MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM medicine", con);
			MySqlDataReader r = query.ExecuteReader();

			int x = 0;
			int i = 0;

			while (r.Read())
			{
				x = r.GetInt32(0);
				++i;
			}

			con.Close();
			///////////////////////////////////////////

			Medicine[] medicine = new Medicine[x];

			///////////////////////////////////////////
			con.Open();

			query = new MySqlCommand("SELECT * FROM medicine", con);
			r = query.ExecuteReader();

			i = 0;
			string name;
			int minLife;
			int maxLife;
			int healingPower;
			int energizingPower;
			int price;

			while (r.Read())
			{
				name = r.GetString(1);
				minLife = r.GetInt32(2);
				maxLife = r.GetInt32(3);
				healingPower = r.GetInt32(4);
				energizingPower = r.GetInt32(5);
				price = r.GetInt32(6);

				medicine[i] = new Medicine(name, minLife, maxLife, healingPower, energizingPower, price);
				i++;
			}

			con.Close();
			///////////////////////////////////////////

			return medicine;
		}

		public PokeballItem[] DataLoaderPokeballs()
		{
			MySqlConnection con;
			con = new MySqlConnection("server=127.0.0.1; database=prueba4; Uid=root; password=root; port=3306"); // pwd=root;

			///////////////////////////////////////////
			con.Open();

			MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM pokeballs", con);
			MySqlDataReader r = query.ExecuteReader();

			int x = 0;
			int i = 0;

			while (r.Read())
			{
				x = r.GetInt32(0);
				++i;
			}

			con.Close();
			///////////////////////////////////////////

			PokeballItem[] pokeballs = new PokeballItem[x];

			///////////////////////////////////////////
			con.Open();

			query = new MySqlCommand("SELECT * FROM pokeballs", con);
			r = query.ExecuteReader();

			i = 0;
			string name;
			int capRatio;
			int price;

			while (r.Read())
			{
				name = r.GetString(1);
				capRatio = r.GetInt32(2);
				price = r.GetInt32(3);

				pokeballs[i] = new PokeballItem(name, capRatio, price);
				i++;
			}

			con.Close();
			///////////////////////////////////////////

			return pokeballs;
		}

		public Treasure[] DataLoaderTreasures()
		{
			MySqlConnection con;
			con = new MySqlConnection("server=127.0.0.1; database=prueba4; Uid=root; password=root; port=3306"); // pwd=root;

			///////////////////////////////////////////
			con.Open();

			MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM treasures", con);
			MySqlDataReader r = query.ExecuteReader();

			int x = 0;
			int i = 0;

			while (r.Read())
			{
				x = r.GetInt32(0);
				++i;
			}

			con.Close();
			///////////////////////////////////////////

			Treasure[] treasures = new Treasure[x];

			///////////////////////////////////////////
			con.Open();

			query = new MySqlCommand("SELECT * FROM treasures", con);
			r = query.ExecuteReader();

			i = 0;
			string name;
			int price;

			while (r.Read())
			{
				name = r.GetString(1);
				price = r.GetInt32(2);

				treasures[i] = new Treasure(name, price);
				i++;
			}

			con.Close();
			///////////////////////////////////////////

			return treasures;
		}

		public Move[] DataLoaderMoves()
		{
			MySqlConnection con;
			con = new MySqlConnection("server=127.0.0.1; database=prueba4; Uid=root; password=root; port=3306"); // pwd=root;

			///////////////////////////////////////////
			con.Open();

			MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM moves", con);
			MySqlDataReader r = query.ExecuteReader();

			int x = 0;
			int i = 0;

			while (r.Read())
			{
				x = r.GetInt32(0);
				++i;
			}

			con.Close();
			///////////////////////////////////////////

			Move[] moves = new Move[x];

			///////////////////////////////////////////
			con.Open();

			query = new MySqlCommand("SELECT * FROM moves", con);
			r = query.ExecuteReader();

			i = 0;
			int num;
			string name;
			int pp;
			int power;
			int precision;
			int priority;

			while (r.Read())
			{
				num = r.GetInt32(0);
				name = r.GetString(1);
				pp = r.GetInt32(2);
				power = r.GetInt32(3);
				precision = r.GetInt32(4);
				priority = r.GetInt32(5);

				moves[i] = new Move(num, name, pp, power, precision, priority);
				i++;
			}

			con.Close();
			///////////////////////////////////////////

			return moves;
		}

		public MT[] DataLoaderMTS(Move[] moves)
		{
			MySqlConnection con;
			con = new MySqlConnection("server=127.0.0.1; database=prueba4; Uid=root; password=root; port=3306"); // pwd=root;

			///////////////////////////////////////////
			con.Open();

			MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM colors", con);
			MySqlDataReader r = query.ExecuteReader();

			int x = 0;
			int i = 0;

			while (r.Read())
			{
				x = r.GetInt32(0);
				++i;
			}

			con.Close();
			///////////////////////////////////////////

			MT[] mts = new MT[x];

			///////////////////////////////////////////
			con.Open();

			query = new MySqlCommand("SELECT * FROM mts", con);
			r = query.ExecuteReader();

			i = 0;
			int num;
			string name;

			while (r.Read())
			{
				num = r.GetInt32(0);
				name = r.GetString(1);

				mts[i] = new MT(name, moves[num]);
				i++;
			}

			con.Close();
			///////////////////////////////////////////

			return mts;
		}

		// To do: Generic DataLoader.

		public Pokemon[] MirrorMatrix(Pokemon[] fighters)
		{
			Pokemon[] fightersAlt = new Pokemon[fighters.Length];
			fightersAlt[1] = fighters[0];
			fightersAlt[0] = fighters[1];
			fighters[0] = fightersAlt[0];
			fighters[1] = fightersAlt[1];
			return fighters;
		}

		public void Export(Player player, string exportPath)
		{
			FileStream x;
			x = File.Open(exportPath, FileMode.OpenOrCreate);
			using (StreamWriter sw = new StreamWriter(x))
			{
				sw.WriteLine("Información del jugador \"" + player.GetName() + "\" " + player.GetSexChar() + ":");
				sw.WriteLine("\tID: " + player.GetID());
				sw.WriteLine("\tPokedólares: " + player.GetMoney());
				sw.WriteLine("\tPuntos de batalla: " + player.GetBattlePoints());
				sw.WriteLine("\tPokesemillas: " + player.GetPokeSeeds());
				sw.WriteLine("");
				sw.WriteLine("\tEquipo: ");

				for(int i = 0; player.GetTeam().GetPokemon(i) != null; i++)
				{
					sw.WriteLine("\t\tPokémon \"" + player.GetTeam().GetPokemon(i).GetName() + "\" " + player.GetTeam().GetPokemon(i).GetSexChar());
				}
			}
			x.Close();
			return;
		}
	}
}
