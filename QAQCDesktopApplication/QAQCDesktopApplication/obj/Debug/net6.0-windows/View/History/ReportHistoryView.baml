   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:QAQCDesktopApplication.View.History#QAQCDesktopApplication.View.History  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5
      ]3clr-namespace:QAQCDesktopApplication.ValueConverter%QAQCDesktopApplication.ValueConverter  5      ;    5QAQCDesktopApplication.View.History.ReportHistoryView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:QAQCDesktopApplication.View.History     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools  5
      @local23clr-namespace:QAQCDesktopApplication.ValueConverter  5      $	��680��5      $
��1060��6      MaterialDesignBody#���   5      $��Regular"�5   	   $
��13pt(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���#E8EAF6$��Arial)�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��9* �6   .+�5   
   � -   5         �Name$ Size1��5      $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5       ���	#FF084784$
��17pt(�5!   0   
������ $��Calibri)�5"   3    � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��5#      $��LỊCH SỬ CHỈNH SỬA��6V     MaterialDesignRaisedButton#��[ 5$      ��5      ��  �� Path$ ActualHeight�	 �� ElementName$	 Size1��
 �� 	Converter
 F   @QAQCDesktopApplication.ValueConverter.MyApp.Tools.RatioConverter   �� ConverterParameter$ 1����5%      �� *EditCommand+�� 5&      #��[ 6   $ 0��5(      ���	#FF4185C7$��1��5)   (   $
��17pt(�68   ���	#00000000$��Calibri)�5*   )   $ Depth0=�5+      $8 2Resource name: MaterialDesignRaisedLightDarkButton��5,      $��LỊCH SỬ BÁO CÁO��6N   ��5'      �� $ ActualHeight�$	 Size1��
   $ 1����5-      �� *ReportCommand+5.      5/      � 50   
   $��1��6   $��10q�6    51      �� 52      $��* �6    �� 53      $	��10* �6    .+�55      � -   5        $ Grid1��55       $��0��6    56      �� 57      $��* �6'   �� 58      $
��auto �6'   �� 59      $��5* �6'   �� 5:      $��3* �6'   �� 5;      $
��auto �6'   �� 5<      $��5* �6'   �� 5=      $��5* �6'   �� 5>      $��4* �6'   .+�5@      �� $��1��6   $��Từ ngày:��6,   $
��13pt(�6<   $��Center=�6L   � 5A      $��2��6   .+�5B      (  "System.Windows.Controls.DatePicker  ���	#FFD3E1E6
�������$��	10 0 10 0q�6K   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Pick Date��5C      $
��13pt(�6D     CustomCalendar   CalendarStyle# [ 5E      ��5D      �� $ ActualHeight�$	 Grid1��
   $
 0.75��   SelectedDate 5F      �� *	startDate+5G      �� 5H      $��4��6   $��Đến ngày:��6,   $
��13pt(�6=   $��Center=�6M   � 5I      $��5��6   .+�5J        ���	#FFD3E1E6
�������$��	10 0 10 0q�6K   $ 	Pick Date��5K      $
��13pt(�6D   # [ 5M      ��5L      �� $ ActualHeight�$	 Grid1��
   $
 0.75�� 5N      �� *
stopDate+5O      �� 5P      #��[ 6   $��7��6M   $ 0��5R      $
��10 0q�6B   ���	#FF2673BF$
��14pt(�5S   ,   
������ $8 2Resource name: MaterialDesignRaisedLightDarkButton��5T      $	��XEM��5U      ��5Q      �� $ ActualHeight�$	 Grid1��
   $ 1����5U   #   �� *ViewCommand+5V      � 5W      $��1��6   $��10q�6    .+�5X      &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyListView��5_   #   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5X        DataGridColumnHeaderStyle2   ColumnHeaderStyle# [ 5Y         CanUserReorderColumns$ False��5Z      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 	10 2 -5 2q�5[         ColumnHeaderPadding$ 	0 20 -2 2q�5\         AutoGenerateColumns$ False��5]         
IsReadOnly$
 True��6/      SelectionUnit$ FullRow=�6A      RowBackground �	#FFD4D6EA   AlternatingRowBackground
 �����$
��13pt(�5_      ��5X   @   �� *historyReport+ � 	Resources 5`      <	   6QAQCDesktopApplication.ValueConverter.OrdinalConverter  OrdinalConverter  OrdinalColumnDataTemplate �� RelativeSource �� Mode �� AncestorType��%�   &	       &	      7  	  5a      62   �� 5b      .R�5c      �� $��Center=�5d   S   ��5c   (   ��  �� $ FindAncestor=� DataGridRow8
   5d   S   5e      5f         Columns 5g      4
  .System.Windows.Controls.DataGridTemplateColumn
  5h      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 65 61       Header$	  STT��6<   ! 
  CellTemplate#! [ 6I   5i      0  *System.Windows.Controls.DataGridTextColumn  5j      $	 177 6-   $  MÃ SẢN PHẨM��6W   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 69   �� *	productId+6W     5k      $	 277 6-   $  TÊN SẢN PHẨM��6R   " 69   �� *name+6R     5l      $	 177 6-   $  NGƯỜI XUẤT��6R   " 69   �� *User+6R     5m      $	 275 6-   $  NGÀY XUẤT BÁO CÁO��6R   " 69   �� *Date+6R   # J� InputBindings# 5o      d� 5p      $ d� MouseAction$$ LeftDoubleClicke�6'   % �� Command% 5q      �� *DetailCommand+& �� CommandParameter& 5r      �� $	 
MyListView��$ SelectedItems�5s      5u      5v      5w      5x      5y      