   M S B A M L   `   `   `  ����B  >Mishlen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Mishlen.PagesMishlen.Pages  5          Mishlen.Pages.PageMain   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Mishlen.Pages     5        N� Title$$  Товары на складе��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��43* �6   �� 5      $
��207* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��25 0 0 0q�6.   .+�5      �� -   5         ��Name$ 	txbSearch��5   .   $��35��6   $	��300��6"   $��Поиск товара��5      $
��Left=�6*   $��Center=�5       J� Opacity$	 0.9Q�68    �� 	MaxLength$ 30��5   2   �� 5      -   5         ��Name$ cmbFilt��5      $��25 0 0 0q�6(   $��35��6:   $	��215��5      6#   �� 5      -   5        $ cmbSort��5      $��25 0 0 0q�6(   $��35��6:   $	��215��5      6#   5       �� 5"   
   $��Center=�6   $��Center=�60   $��1��6M   .+�5#      �� -   5         ��Name$ 	lbProduct��5#      $	��780��6)   $	��300��65   $ .8Q�6B   ��5$      �� 5%      .R�5&      �� .+�5'      �� $ 
Horizontal=�6)   .+�5(   "   �� $	��100��6(   ��5)   &   �� 5*   *    �� Path$ Image�62   	 �� TargetNullValue	 5+   .   ��5,   2   /Resource/WheelNull.png��6W   5.   +   50   #   �� 52   "   $��Center=�6-   $��Center=�6H   $��10q�53   )   $	��250��65   .+�55   &   �� $ 
Horizontal=�61   .+�56   *   �� ��64   �� *Name+
 �� StringFormat$
 Товар: {0}���� 59   *   $�� ��64   �� 5;   *   ��64   �� *
Category+5<   '   �� 5=   &   ��60   �� *ProductType.Name+$
 Сезон: {0}���� 5@   &   ��60   �� *Price+$ 
 Цена: {0} рублей��5B   #   �� 5D   "   $��0 50 0 0q�5E   D   $	��200��5F   ,   ��5D   ,   �� *CountInStrock+$
 Кол-во: {0}��5F   ,   �� 5H   "    ��Name$ ButtonDelete��6)   -   5        $��50��5H   ?   $��0 0 10 0q�6K   .��5J   &   �� $��/Resource/Delete.png��6,   5K   #   �� 5M   "   $ 
ButtonEdit��6)   -   5        $��50��5M   =   .��5O   &   �� $��/Resource/Edit.png��6,   5P   #   5Q      5R      5S      5U      5V      5W      5X      