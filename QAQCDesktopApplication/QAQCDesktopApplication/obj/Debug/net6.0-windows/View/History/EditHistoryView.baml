   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:QAQCDesktopApplication.View.History#QAQCDesktopApplication.View.History  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5	      ]3clr-namespace:QAQCDesktopApplication.ValueConverter%QAQCDesktopApplication.ValueConverter  5      9    3QAQCDesktopApplication.View.History.EditHistoryView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:QAQCDesktopApplication.View.History     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools  5	      @local23clr-namespace:QAQCDesktopApplication.ValueConverter  5      $	��680��5      $
��1060��6      MaterialDesignBody#���   5
      $��Regular"�5   	   $
��13pt(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���#E8EAF6$��Arial)�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��9* �6   .+�5   
   � -   5         �Name$ Size1��5      $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      ���	#FF4185C7$
��17pt(�5    0   
������ $��Calibri)�5!   3    � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��5"      $��LỊCH SỬ CHỈNH SỬA��6V     MaterialDesignRaisedButton#��[ 5#      ��5      ��  �� Path$ ActualHeight�	 �� ElementName$	 Size1��
 �� 	Converter
 F   @QAQCDesktopApplication.ValueConverter.MyApp.Tools.RatioConverter   �� ConverterParameter$ 1����5$      �� *EditCommand+�� 5%      #��[ 6   $ 0��5'      ���	#FF084784$��1��5(   (   $
��17pt(�68   ���	#00000000$��Calibri)�5)   )   $ Depth0=�5*      $8 2Resource name: MaterialDesignRaisedLightDarkButton��5+      $��LỊCH SỬ BÁO CÁO��6N   ��5&      �� $ ActualHeight�$	 Size1��
   $ 1����5,      �� *ReportCommand+5-      5.      � 5/   
   $��1��6   $��10q�6    50      �� 51      $��* �6    �� 52      $	��10* �6    .+�54      � -   5        $ Grid1��54       $��0��6    55      �� 56      $��* �6'   �� 57      $
��auto �6'   �� 58      $��5* �6'   �� 59      $
��2.5* �6'   �� 5:      $
��auto �6'   �� 5;      $��5* �6'   �� 5<      $��5* �6'   �� 5=      $��4* �6'   .+�5?      �� $��1��6   $��Từ ngày:��6,   $
��13pt(�6<   $��Center=�6L   � 5@      $��2��6   .+�5A      (  "System.Windows.Controls.DatePicker  ���	#FFD3E1E6
�������$��	10 0 10 0q�6K   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Pick Date��5B      $
��13pt(�6D     CustomCalendar   CalendarStyle# [ 5D      ��5C      �� $ ActualHeight�$	 Grid1��
   $
 0.75��   SelectedDate 5E      �� *	startDate+5F      �� 5G      $��4��6   $��Đến ngày:��6,   $
��13pt(�6=   $��Center=�6M   � 5H      $��5��6   .+�5I        ���	#FFD3E1E6
�������$��	10 0 10 0q�6K   $ 	Pick Date��5J      $
��13pt(�6D   # [ 5L         IsTodayHighlighted$
 true��5M   ;   ��5K      �� $ ActualHeight�$	 Grid1��
   $
 0.75�� 5M      �� *
stopDate+6;   5N      �� 5O      #��[ 6   $��7��6M   $ 0��5Q      $
��10 0q�6B   ���	#FF2673BF$
��14pt(�5R   ,   
������ $8 2Resource name: MaterialDesignRaisedLightDarkButton��5S      $	��XEM��5T      ��5P      �� $ ActualHeight�$	 Grid1��
   $ 1����5T   #   �� *ViewCommand+5U      � 5V      $��1��6   $��10q�6    .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyListView��5^   #   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5W        DataGridColumnHeaderStyle2   ColumnHeaderStyle# [ 5X         CanUserReorderColumns$ False��5Y      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 	10 2 -5 2q�5Z         ColumnHeaderPadding$ 	0 20 -2 2q�5[         AutoGenerateColumns$ False��5\         
IsReadOnly$
 True��6/      SelectionUnit$ FullRow=�6A      RowBackground �	#FFD4D6EA   AlternatingRowBackground
 �����$
��13pt(�5^      ��5W   @   �� *historyEdit+ � 	Resources 5_      <	   6QAQCDesktopApplication.ValueConverter.OrdinalConverter  OrdinalConverter  OrdinalColumnDataTemplate �� RelativeSource �� Mode �� AncestorType��%�   &	       &	      7  	  5`      62   �� 5a      .R�5c      �� $��Center=�5d   S   ��5c   (   ��  �� $ FindAncestor=� DataGridRow8
   5d   S   5e      5f         Columns 5g      4
  .System.Windows.Controls.DataGridTemplateColumn
  5h      ,  &System.Windows.Controls.DataGridColumn    Width5  /System.Windows.Controls.DataGridLengthConverter$  65 61   !   Header$	! STT��6<   " 
  CellTemplate#" [ 6I   5i      0  *System.Windows.Controls.DataGridTextColumn  5j      $	  157 6-   $! MÃ SẢN PHẨM��6W   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 69   �� *	productId+6W     5k      $	  267 6-   $! TÊN SẢN PHẨM��6R   # 69   �� *name+6R     5l      $	  207 6-   $! NGƯỜI SỬA��6R   # 69   �� *User+6R     5m      $	  277 6-   $! NGÀY CẬP NHẬT��6R   # 69   �� *Date+6R   4  .System.Windows.Controls.DataGridCheckBoxColumn  5n      $	  110 61   $! 	ĐÃ XÓA��6[   # 6=   �� *	IsDeleted+6[   $ J� InputBindings$ 5p      d� 5q      % d� MouseAction$% LeftDoubleClicke�6'   & �� Command& 5r      �� *DetailCommand+' �� CommandParameter' 5s      �� $	 
MyListView��$ SelectedItems�5t      5v      5w      5x      5y      5z      