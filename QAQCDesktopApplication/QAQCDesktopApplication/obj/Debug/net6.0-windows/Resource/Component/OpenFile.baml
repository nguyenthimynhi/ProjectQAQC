   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:QAQCDesktopApplication.Resource.Component)QAQCDesktopApplication.Resource.Component  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5	      8    2QAQCDesktopApplication.Resource.Component.OpenFile   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:QAQCDesktopApplication.Resource.Component     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools  5	         MaterialDesignBody#���   5
      $��Regular"�5   	   $
��13pt(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   $��Arial)�5   	   $��70��5   	   $
��1020��6   $
��13pt(�5   	   $��Regular"�6   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    .+�5      � -   5         �Name$ Grid1��5       $��0��6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��7.8* �6'   .+�5      � $��0��6   .+�5      �� 
������ ���	#FFD1D1D6
���   �$��Regular"�6a     MaterialDesignRaisedButton#��[ 5        � ToolTip$! MaterialDesignFlatMidButton��5!      $��	Open File��6?   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5"         ShadowEdges$
 None=�5#      $	��0 3q�5$      $
��13pt(�6&   $��Center=�66   ��5      ��  �� Path$ ActualHeight�	 �� ElementName$	 Grid1����5%      �� *OpenFileCommand+5&      � 5'      $��1��6   .+�5(      �� $��3 3 0 3q�6   $��0q�6/   $��5 5 5 0q�6C   ���	#FFD1D1D6
���   ���6U   �� *
TextFile+5)   ,   5*      5+      � 5,      $��1��6    5-      �� 5.      $��2.18* �6'   �� 5/      $��2.35* �6'   �� 50      $��2.15* �6'   �� 51      $��2.35* �6'   �� 52      $
��2.2* �6'   �� 53      $
��7.9* �6'   .+�55      �� $��0��6   $��Mã tiêu chuẩn:��6,   $��Center=�6B   $��4 0 0 0q�6]   �� 56      $��1��6   $��3 3 0 3q�6*   ���	#FFD1D1D6$��5 5 5 0q�6R   
���   �$��0q�57   -   ��6A   �� *
IdStandard+�� 58      $��2��6   $��Mã sản phẩm:��6,   $��Center=�6@   $��4 0 0 0q�6[   �� 59      $��3��6   $��3 3 0 3q�6+   ���	#FFD1D1D6$��5 5 5 10q�6S   
 �� 
IsEditable$

 True��6f   
���   �$��0q�5:   .    �� Text 6B   �� *	IdProduct+��5;      �� *ListProducts+��5<      �� 5=      .R�5>      �� ��6(   �� 5?      5A      �� 5B      $��4��6   $��Tên sản phẩm:��6,   $��Center=�6A   $��2 0 0 0q�6\   �� 5C      $��5��6   $��3 3 0 3q�6*   ���	#FFD1D1D6$��5 5 5 0q�6S   
���   �$��0q�5D   -   ��6A   �� *NameProduct+.��6^    J� InputBindings 5E      d� 5F       d� MouseAction$ 	LeftClicke�6G    �� Command 6'   �� *LoadCommand+6G   .��5G   -   5H      5I      5J      5K      5L      