   M S B A M L   `   `   `  ����B  >Mishlen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MishlenMishlen  5   	       Mishlen.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Mishlen     5   	     � Title$0  *Продажа товаров Мишлен��5   	   $	��500��6(   $
��1000��65    � Icon$ /Resource/Logo.png��6B    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��51* �6   �� 5      $
��433* �6    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $	��21* �6   .+�5   
    � $��2��6   ���	#FF27509B6!    � 5   
   $��1��6   $��2��6    ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF3772DC��6#   � 5      $ 	#FF2F61BB��6#   	 � Offset$	 1Q�65   5      5      �� 5!   
   $��1��6M   $��Center=�5"      $��Center=�65   $��24(�5#         Text#��[  6"   ��5!      �� 
 �� ElementName$
 FrmMain�� �� Path$ Content.Title�5#   "   �� 5&   
   $��/Resource/Icon.png��6    J� Opacity$	 0.1Q�6,   $��1��6:   $��1��6J    � 5'   
   -   5          �Name$ FrmMain��5'        � NavigationUIVisibility$ Hidden=�6!   $��1��5(      $��1��6    �� 5,   
   -   5         ��Name$ spMenu��5,      $��1��6&   .+�5.      �� -   5         ��Name$ ButtonOrders��5.   2   $��50��6   $��Заказы��6!   5/      �� 50      -   5        $ ButtonClients��50   3   $��50��6   $��Клиенты��6!   51      �� 52      -   5        $ ButtonProducts��52   <   $��50��6   $$��Товары на складе��6!   53      54      �� 57   
   -   5        $ ButtonSettings��57   2   $��50��6   $��Добавление��6   $��1��6J   $��Bottom=�58      60   5:      5;      