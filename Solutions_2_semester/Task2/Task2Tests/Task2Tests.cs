using NUnit.Framework;
using SomeIceCreams;

namespace Task2Tests
{
	public class MainTests
	{
		class TestIceCreamCreamyBriquetteCount70 : AbstractIceCream.AbstractIceCream
		{
			public TestIceCreamCreamyBriquetteCount70()
			{
				type = Type.creamy;
				innings = Innings.briquette;
				count = 70;
			}
		}
		class TestIceCreamCholateBallCount3 : AbstractIceCream.AbstractIceCream
		{
			public TestIceCreamCholateBallCount3()
			{
				type = Type.chocolate;
				innings = Innings.ball;
				count = 3;
			}
		}
		class TestIceCreamStrawberryonStickCount6 : AbstractIceCream.AbstractIceCream
		{
			public TestIceCreamStrawberryonStickCount6()
			{
				type = Type.strawberry;
				innings = Innings.onStick;
				count = 6;
			}
		}
		class TestIceCreamPistachioWithWaffleCount140 : AbstractIceCream.AbstractIceCream
		{
			public TestIceCreamPistachioWithWaffleCount140()
			{
				type = Type.pistachio;
				innings = Innings.withWaffle;
				count = 140;
			}
		}
		class TestIceCreamCaramelinTheHornCount1 : AbstractIceCream.AbstractIceCream
		{
			public TestIceCreamCaramelinTheHornCount1()
			{
				type = Type.caramel;
				innings = Innings.inTheHorn;
				count = 1;
			}
		}
		class TestIceCreamSpeciallinTheHornCount0xf0 : AbstractIceCream.AbstractIceCream
		{
			public TestIceCreamSpeciallinTheHornCount0xf0()
			{
				type = Type.special;
				innings = Innings.inTheHorn;
				count = 0xf0;
			}
		}

		[Test]
		public void CreamyBriquetteCount70()
		{
			const string TestString =
				@"������ ���������� ������� ����������� 70�.

				�����������

				����������:
					������ 33% �������� - 35��;
					������ - 25��;
					����� - 10�
					������ ������ - 1��;
					������� - �� �����

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������ ������������.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������.";
			AbstractIceCream.AbstractIceCream testIceCream = new TestIceCreamCreamyBriquetteCount70();
			Assert.Pass(TestString, testIceCream.GetRecipe());
		}
		[Test]
		public void StrawberryonStickCount6()
		{
			const string TestString =
				@"������ ����������� ����������� �� �������, 6��.

				�����������

				����������:
						������ 33% �������� - 210��;
						������ - 150��;
						����� - 60�
						������ ������ - 1��;
						�������� - 120�;
						������� ��� ����������� - 6��.

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				��������� ����� � �������� �����.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������ ������������.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������, �������� � ����� ����� ������� ��� �����������.";
			AbstractIceCream.AbstractIceCream testIceCream = new TestIceCreamStrawberryonStickCount6();
			Assert.Pass(TestString, testIceCream.GetRecipe());
		}
		[Test]
		public void CholateBallCount3()
		{
			const string TestString =
				@"������ �����������  ����������� � �������, 3��.

				�����������

				����������:
						������ 33% �������� - 105��;
						������ - 75��;
						����� - 30�
						������ ������ - 1��;
						����� - 60�

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				��������� � �������� ����� �����.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������ ������������.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������.
				����� ������� ���������� ������������ �� ����������� ������, 3��.";
			AbstractIceCream.AbstractIceCream testIceCream = new TestIceCreamCholateBallCount3();
			Assert.Pass(TestString, testIceCream.GetRecipe());
		}
		[Test]
		public void PistachioWithWaffleCount140()
		{
			const string TestString =
				@"������ ������������ ����������� � ������ 140�.

				�����������

				����������:
						������ 33% �������� - 70��;
						������ - 50��;
						����� - 20�
						������ ������ - 1��;
						�������� - 40�
				
				�����:
						��������� ����� - 20�;
						�����  - 33�;
						����  - 1��;
						����  - 26�;
						���� - �� �����

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				���������� �������� �� ��������� ����. ��������� �������� � �������� �����.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������ ������������.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������.

				�����:
				��������� ������������ ��������� �����, �����, ���� � ����. ��������� ������� ���� �
				���������� ����� ��� ������. �� ������������ ��� ������ ���������� ��� �������.
				��� ������������� ����������� ����������.
				�������� ������� ����� �� ����������� ������ ���������� � ��������.";
			AbstractIceCream.AbstractIceCream testIceCream = new TestIceCreamPistachioWithWaffleCount140();
			Assert.Pass(TestString, testIceCream.GetRecipe());
		}
		[Test]
		public void CaramelinTheHornCount1()
		{
			const string TestString =
				@"������ ������������ ����������� � �����, 1��.

				�����������

				����������:
						������ 33% �������� - 35��;
						������ - 25��;
						����� - 10�
						������ ������ - 1��;
						�������� - 20�

				�����:
						��������� ����� - 10�;
						�����  - 16�;
						����  - 1��;
						����  - 13�;
						���� - �� �����

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				��������� � �������� ����� ��������.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������ ������������.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������.

				�����:
				��������� ������������ ��������� �����, �����, ���� � ����. ��������� ������� ���� �
				���������� ����� ��� ������. �� ������������ ��� ������ ���������� ��� �������.
				��� ������������� ����������� ����������.
				�������� ������� ����� �� ����������� ������ ���������� � ��������.
				������ ������, ����� ������ ��������� �����, ���� �� �� ������ � �� ���� ������.";
			AbstractIceCream.AbstractIceCream testIceCream = new TestIceCreamCaramelinTheHornCount1();
			Assert.Pass(TestString, testIceCream.GetRecipe());
		}
		[Test]
		public void SpeciallinTheHornCount0xf0()
		{
			const string TestString =
				@"������ ������������ ����������� � �����, 0xF0 ��.

				�����������

				����������:
						������ 33% �������� - 0x20D0 ��;
						������ - 0x1770 ��;
						����� - 0x960 �
						������ ������ - 0x48 ��;
						������������� �� ��������� ������ ����������� ��� ������ - 0x12C0 �;
						���������� ������ �� ��� ���������� - �� �����

				�����:
						��������� ����� - 0x960 �;
						�����  - 0xFA0 �;
						����  - 0x40 ��;
						����  - 0xC80 �;
						���� - �� �����

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				��� ����� ����� � ����������� ������� ����� ������ � �������� �����
				������������� �� ��������� ������ ����������� ��� ������. ��������� ���������� ������.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������������ ����� 42 ���� �� ���������
				���� 42 (0 - ������, 1 - �����), ��� ����  ������������ Ubuntu 14.04 � ������� mysql �� ���.
				��� ���������� ��������� ��-�� ��������������� ������,
				�������� �������� ����� � �������� ������������� ����������� ������,
				�������������� �������������� ������ ���� ��� ��������� ��������� Ubontu.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������.

				�����:
				��������� ������������ ��������� �����, �����, ���� � ����. ��������� ������� ���� �
				���������� ����� ��� ������. �� ������������ ��� ������ ���������� ��� �������.
				��� ������������� ����������� ����������.
				�������� ������� ����� �� ����������� ������ ���������� � ��������.
				������ ������, ����� ������ ��������� �����, ���� �� �� ������ � �� ���� ������.

				����������� ���������� �� ����� ��� �������� �� ��������:


										 .mmMMMMMMm.
										 MMMMMMMMMMNI
										MMMMMMMMMMMMM
										MMMMMMMMMMMM
										!MMMMMMMMMMM
										! MMMMMMMM.
										. !MM\!\!\!
										 .!\M\!\!\!.
										 !\!\!\!\!\!
										.!\!\!\!\!\!.
										!\!\!\!\!\!\!
									   .!\!\!\!\!\!\!.
									   !\!\!\!\!\!\!\!
									  .!\!\!\!\!\!\!\!.
									  !\!\!\!\!\!\!\!\!";
			AbstractIceCream.AbstractIceCream testIceCream = new TestIceCreamSpeciallinTheHornCount0xf0();
			Assert.Pass(TestString, testIceCream.GetRecipe());
		}
		[Test]
		public void PopularIceCreamTest()
		{
			AbstractIceCream.AbstractIceCream streetStravberryIceCream = new StreetStravberry();
			AbstractIceCream.AbstractIceCream waffleChocoIceCream = new WaffleChoco();
			AbstractIceCream.AbstractIceCream specialIceCream = new Special();
			const string TestStreetStravberryIceCreamString =
				@"������ ����������� ����������� �� �������, 1��.

				�����������

				����������:
						������ 33% �������� - 35��;
						������ - 25��;
						����� - 10�
						������ ������ - 1��;
						�������� - 20�;
						������� ��� ����������� - 1��.

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				��������� ����� � �������� �����.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������ ������������.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������, �������� � ����� ����� ������� ��� �����������.";


			const string TestWaffleChocoIceCreamString =
				@"������ ����������� ����������� � ������ 200�.

				�����������

				����������:
						������ 33% �������� - 70��;
						������ - 50��;
						����� - 20�
						������ ������ - 1��;
						����� - 40�

				�����:
						��������� ����� - 20�;
						�����  - 33�;
						����  - 1��;
						����  - 26�;
						���� - �� �����

				������������

				����������:
				������ ��������� � ������� � ���������.
				������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
				������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
				�� �������! ����� �������� �� ��������� �����������.
				��������� � �������� ����� �����.
				����������� ������ �������� �� ���������� �����.
				������ � ������ �������� �������-��������� �����. ������ ������������.
				����������� � ����� � ���������� ������� � ����������� ������.
				����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
				�� ������� ����������.

				�����:
				��������� ������������ ��������� �����, �����, ���� � ����. ��������� ������� ���� �
				���������� ����� ��� ������. �� ������������ ��� ������ ���������� ��� �������.
				��� ������������� ����������� ����������.
				�������� ������� ����� �� ����������� ������ ���������� � ��������.";

		const string TestSpecialIceCreamString =
			@"������ ������������ ������� ����������� 500�.

			�����������

			����������:
					������ 33% �������� - 0xF5 ��;
					������ - 0xAF ��;
					����� - 0x46 �
					������ ������ - 0x2 ��;
					������������� �� ��������� ������ ����������� ��� ������ - 0x8C �;
					���������� ������ �� ��� ���������� - �� �����

			������������

			����������:
			������ ��������� � ������� � ���������.
			������ ������� �� ������� � ������� � ����. ��������� ������ � ������ ��������� �����,
			������������. ������ �� ����� ����� ����� �, �������, ������� �� ����������.
			�� �������! ����� �������� �� ��������� �����������.
			��� ����� ����� � ����������� ������� ����� ������ � �������� �����
			������������� �� ��������� ������ ����������� ��� ������. ��������� ���������� ������.
			����������� ������ �������� �� ���������� �����.
			������ � ������ �������� �������-��������� �����. ������������ ����� 42 ���� �� ���������
			���� 42 (0 - ������, 1 - �����), ��� ����  ������������ Ubuntu 14.04 � ������� mysql �� ���.
			��� ���������� ��������� ��-�� ��������������� ������,
			�������� �������� ����� � �������� ������������� ����������� ������,
			�������������� �������������� ������ ���� ��� ��������� ��������� Ubontu.
			����������� � ����� � ���������� ������� � ����������� ������.
			����� ��� �������, ������������ �������� � ���������� ��������� ������� � �����������
			�� ������� ����������.";

		Assert.Pass(TestSpecialIceCreamString, specialIceCream.GetRecipe());
		Assert.Pass(TestStreetStravberryIceCreamString, streetStravberryIceCream.GetRecipe());
		Assert.Pass(TestWaffleChocoIceCreamString, waffleChocoIceCream.GetRecipe());
		}
	}
}