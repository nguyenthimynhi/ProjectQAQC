   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:QAQCDesktopApplication.View.QCView"QAQCDesktopApplication.View.QCView  5      e7clr-namespace:QAQCDesktopApplication.Resource.Component)QAQCDesktopApplication.Resource.Component  5	      W0clr-namespace:QAQCDesktopApplication.View.QCView"QAQCDesktopApplication.View.QCView  5
      ]3clr-namespace:QAQCDesktopApplication.ValueConverter%QAQCDesktopApplication.ValueConverter  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5      3    -QAQCDesktopApplication.View.QCView.MainQCView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      <local0clr-namespace:QAQCDesktopApplication.View.QCView  5      G	component7clr-namespace:QAQCDesktopApplication.Resource.Component  5	      :uc20clr-namespace:QAQCDesktopApplication.View.QCView  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      C	converter3clr-namespace:QAQCDesktopApplication.ValueConverter  5      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools  5      -   5          >�Name$	  MQC��5      $	��680��5      $
��1060��6      MaterialDesignBody#���   5      $��Regular"�5      $
��13pt(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      ���#E8EAF6$��Arial)�5      $��Stretch=�5      $��Stretch=�6$   $��10q�5      .��5      � .+�5   
   )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 	DialogBox��5   $   $��Center=�5      $��Arial)�6.   $��Center=�5         DialogTheme$ Inherit=�5         IsOpen 5      �� *IsDialogOpen+   DialogContent 5      :   4QAQCDesktopApplication.Resource.Component.MessageBox  5       � DataContext 6'   �� *
MessageBox+5!      � 5"   
    � RowDefinitions 5#      �� 5$      $
��0.9* �6    �� 5%      $
��0.8* �6    �� 5&      $
��0.9* �6    �� 5'      $��7* �6    �� 5(      $
��5.4* �6    .+�5*      �� $��0��6   $
��17pt(�6%   	 �� TextAlignment$	 Center=�65   $��0 4 0 0q�6L   $7��1BÁO CÁO KIỂM TRA CHẤT LƯỢNG SẢN PHẨM��5+      $��Calibri)�69   � 5,      $��1��6   
 � ColumnDefinitions
 5-      �� 5.      $
��auto �6'   �� 5/      $
��5.2* �6'   �� 50      $��12.5* �6'   �� 51      $��4.75* �6'   �� 52      $��4.75* �6'   .+�54      �� $��0��6   $��Mã tiêu chuẩn:��6,   $
��13pt(�6B   $��Center=�6R   � 55      $��1��6   .+�56      �� $��1��6   $
��10 5q�6/   $��Visible=�57      ���	#FFD3E1E6
���   �$��0q�58   ?   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��59      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ 
PrimaryMid=�5:       �� 
IsEditable$
 True��5;       �� Text 5<      �� *ID+.@�5=      �� $��
TC-PQA-093��6'   $��10 -0.8 0 -0.8q�6<   �� 5>      $��
TC-PQA-103��6'   $��10 -0.8 0 -0.8q�6<   �� 5?      $��
TC-PQA-506��6'   $��10 -0.8 0 -0.8q�6<   �� 5@      $��
TC-PQA-464��6'   $��10 -0.8 0 -0.8q�6<    J� InputBindings 5A      d� 5B       d� MouseAction$ 	LeftClicke�6K    �� Command 6+   �� *LoadCommand+6K   5D      5E      � 5F      -   5         �Name$ Grid1��5F   '   $��3��6   .+�5G      ��   MaterialDesignRaisedButton#��[ 6   $	��Top=�6Q   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��5J      $��
0 -5 0 -17q�6B   ���	#FF2673BF$
��14pt(�5K   ,   
������  � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��5L      $��TRUY XUẤT��5M      ��5H      ��  �� Path$ ActualWidth� �� ElementName$ Grid1�� �� 	Converter F   @QAQCDesktopApplication.ValueConverter.MyApp.Tools.RatioConverter   �� ConverterParameter$
 0.92����5I      �� $ ActualHeight�$ Grid1��   $	 1.5����5M   )   �� *ServerCommand+5N      � 5O      -   5        $ Grid2��5O   '   $��4��6   .+�5P      �� #��[ 6   $	��Top=�6Q   $ 0��5S      $��
0 -5 0 -17q�6B   ���	#FF2673BF$
��14pt(�5T   ,   
������ $8 2Resource name: MaterialDesignRaisedLightDarkButton��5U      $��XUẤT EXCEL��5V      ��5Q      �� $ ActualWidth�$ Grid2��   $
 0.92����5R      �� $ ActualHeight�$ Grid2��   $	 1.5����5V   *   �� *ExportCommand+5W      5X      � 5Y      $��2��6   
 5Z      �� 5[      $
��4.6* �6'   �� 5\      $
��auto �6'   �� 5]      $	��15* �6'   �� 5^      $	��15* �6'   �� 5_      $
��auto �6'   �� 5`      $	��15* �6'   �� 5a      $	��44* �6'   .+�5c      �� $��Từ ngày:��6   $
��13pt(�6,   $��Center=�6<   $��1��6W   � 5d      -   5        $ Grid4��5d   '   $��2��6   .+�5e      (  "System.Windows.Controls.DatePicker  ���	#FFD3E1E6
�������$��	10 0 10 0q�6K   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ 	Pick Date��5f      $
��13pt(�6D     CustomCalendar   CalendarStyle# [ 5i      ��5g      �� $ ActualWidth�$ Grid4����5h      �� $ ActualHeight�$ Grid4��   $
 0.75��   SelectedDate 5j      �� *	StartDate+5k      �� 5l      $��4��6   $��Đến ngày:��6,   $
��13pt(�6=   $��Center=�6M   � 5m      $��5��6   .+�5n        ���	#FFD3E1E6
�������$��	10 0 10 0q�6K   $ 	Pick Date��5o      $
��13pt(�6D   # [ 5r      ��5p      �� $ ActualWidth�$ Grid4����5q      �� $ ActualHeight�$ Grid4��   $
 0.75�� 5s      �� *
StopDate+5t      5u      � 5w      $��3��6   .+�5x      1
   +QAQCDesktopApplication.View.QCView.DataGrid
  5y      � 5z      $��4��6   .+�5{      ��  ) %MaterialDesignNavigatilRailTabControl#��[ 6    �� TabStripPlacement$
 Left=�5|      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5}      3  -MaterialDesignThemes.Wpf.NavigationRailAssist   SelectionCornerRadius$ 40 5 5 5��5~         ShowSelectionBackground$
 True��5      y�5{   \   �� *
ReportView+.@�5�      �� $	��115��6   $��50��6+   ��5�      �� 5�      .+�5�   "   '  !MaterialDesignThemes.Wpf.PackIcon      Kind$  Folder=�6:   $��Center=�6H   $��25��6e   $��25��6q   �� 5�   "   $��
CHI TIẾT��6,   $��Center=�6<   $��Calibri)�6Y   ! J� RenderTransformOrigin$! 0.5,0.5&�5�   (   $
��0 20q�6H   z�5�   &   V� 5�   *   .~�5�   .   �� " �� Angle$" 90Q�6>   5�   +   5�   #   5�      .��5�      5   /QAQCDesktopApplication.View.QCView.QCReportView  5�      �� 5�      $	��120��6   $��50��6+   ��5�      �� 5�      .+�5�   "     $  ChartPie=�6:   $��Center=�6J   $��25��6g   $��25��6s   �� 5�   "   $��BIỂU ĐỒ��6,   $��Center=�6;   $��Calibri)�6X   $! 0.5,0.5&�5�   (   $
��0 20q�6H   z�5�   &   V� 5�   *   .~�5�   .   �� $" 90Q�6>   5�   +   5�   #   5�      .��5�      4   .QAQCDesktopApplication.View.QCView.ChartReport  5�      5�      5�      5�      5�      5�      