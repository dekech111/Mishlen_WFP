   M S B A M L   `   `   `  ����B  >Mishlen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Mishlen.PagesMishlen.Pages  5          Mishlen.Pages.PageOrders   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Mishlen.Pages     5        N� Title$  Заказы��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��43* �6   �� 5      $
��207* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��25 0 0 0q�6.   .+�5      �� -   5         ��Name$ 	txbSearch��5   .   $��35��6   $	��300��6"   $��Поиск товара��5      $
��Left=�6*   $��Center=�5       J� Opacity$	 0.9Q�68    �� 	MaxLength$ 30��5   2   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpDateStart��5      $��25 0 0 0q�6.   $��35��6@   $	��215��5      6#     5      -   5        $ 	dpDateEnd��5      $��25 0 0 0q�6,   $��35��6>   $	��215��5      {�.  65   5       �� 5"   
   $��Center=�6   $��Center=�60   $��1��6M   .+�5#      �� -   5         ��Name$ lbOrders��5#      $	��780��6(   $	��300��64   $ .8Q�6A   ��5$      �� 5%      .R�5&      �� .+�5'      �� $ 
Horizontal=�6)   .+�5(   "   �� $	��100��6(   ��5)   &   �� 5*   *    �� Path$ Image�62   	 �� TargetNullValue	 5+   .   ��5,   2   /Resource/WheelNull.png��6W   5.   +   50   #   �� 52   "   $��Center=�6-   $��Center=�6H   $��10q�53   )   $	��500��65   .+�56   &   �� ��60   �� *
ID_Order+
 �� StringFormat$
 №: {0}���� 59   &   $ 
Horizontal=�61   .+�5:   *   �� ��64   �� *Product.Name+$
 Товар: {0}���� 5=   *   $��  ��64   �� 5?   *   ��64   �� *
CountOrder+$
 Кол-во: {0}���� 5B   *   $��  ��64   �� 5D   *   ��64   �� *
SumOrder+$
 Сумма: {0} руб��5F   '   �� 5H   &   ��60   �� *ClientFromOrganization.FIO+$
 Клиент: {0}���� 5K   &   ��60   �� **(ClientFromOrganization.Organization.Name+$!
 Организация: {0}���� 5N   &   ��60   �� *	DateOrder+$5
 /Дата заказа: {0:dd.}{0:MM.}{0:yyyyг}��5P   #   5Q      5R      5S      5U      5V      5W      5X      