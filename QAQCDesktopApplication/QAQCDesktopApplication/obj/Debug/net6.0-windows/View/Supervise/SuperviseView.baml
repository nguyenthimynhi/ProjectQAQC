   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:QAQCDesktopApplication.ViewQAQCDesktopApplication.View  5      ]3clr-namespace:QAQCDesktopApplication.ValueConverter%QAQCDesktopApplication.ValueConverter  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5      e7clr-namespace:QAQCDesktopApplication.Resource.Component)QAQCDesktopApplication.Resource.Component  5      +    %QAQCDesktopApplication.View.Supervise   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:QAQCDesktopApplication.View     5      Flocal23clr-namespace:QAQCDesktopApplication.ValueConverter     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools  5      G	component7clr-namespace:QAQCDesktopApplication.Resource.Component  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      $	��680��5
      $
��1060��6   ���#E8EAF6  � 	Resources  5          BooleanToVisibilityConverter�� 5   
   %   &	        �� 5      6+   5      .��5      � .+�5   
   )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 	DialogBox��5   $   $��Center=�5      $��Arial)�6.   $��Center=�5         DialogTheme$ Inherit=�5         IsOpen 5      �� *IsDialogOpen+   DialogContent 5      :   4QAQCDesktopApplication.Resource.Component.MessageBox  5       � DataContext 6'   �� *
MessageBox+5      � 5   
    � RowDefinitions 5       �� 5!      $
��0.9* �6    �� 5"      $
��1.1* �6    �� 5#      $
��0.9* �6    �� 5$      $	��12* �6    .+�5&      �� $��0��6   $
��17pt(�6%    �� TextAlignment$ Center=�65   $��0 5 0 0q�6L   $B��<KIỂM SOÁT CHẤT LƯỢNG SẢN PHẨM TRONG SẢN XUẤT��5'      $��Calibri)�6A   � 5(      $��1��6   $��5 0 0 0q�6     � ColumnDefinitions 5)      �� 5*      $
��auto �6'   �� 5+      $	��16* �6'   �� 5,      $
��4.5* �6'   �� 5-      $
��4.5* �6'   .+�5/      � -   5        	 �Name$
	 Size��5/      $��0��6%   .+�50      �� $��Ngày sản xuất:��6    $��Center=�66   $��Right=�6Q   $
��13pt(�51       52      (  "System.Windows.Controls.DatePicker  53      $��5 5 6 5q�6   $��1��6/   $��	1 7 450 0q�6?   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 	Pick Date��54      $
��13pt(�6D   ���	#FFBDDFE4
���   �$��0q�55   C   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��56      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ 
PrimaryMid=�57        CustomCalendar   CalendarStyle# [ 58         SelectedDate 59      �� *Date+� 5<      -   5        $	 Size1��5<      $��2��6&   $��	2 5 5 -10q�66   .+�5=      �� +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��5>      ���	#FF2673BF$
��14pt(�5A   0   
������  � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��5C      $��TRUY XUẤT��6V     MaterialDesignRaisedButton#��[ 5D      ��5?      ��  �� Path$ ActualHeight� �� ElementName$ Size1����5@      �� $ ActualWidth�$ Size1����5E      �� *ImportCommand+5F      5G      � 5H      -   5        $	 Size2��5H      $��3��6&   $��	2 5 5 -10q�66   .+�5I      �� #��[ 6   $ 0��5J      ���	#FF2673BF$
��14pt(�5M   ,   ���	#00000000$8 2Resource name: MaterialDesignRaisedLightDarkButton��5O      $��XUẤT EXCEL��6R   ��5K      �� $ ActualHeight�$ Size2����5L      �� $ ActualWidth�$ Size2����5P      �� *ExportCommand+5Q      5R      � 5S      $��2��6   $��5 0 0 0q�6     5T      �� 5U      $
��auto �6'   �� 5V      $	��16* �6'   .+�5X      � -   5        $	 Size5��5X      $��0��6&   .+�5Y      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6.   $��Center=�6=   $��Right=�6X   ���	#FF636363���	#FFBDDFE4$��20��5[   D   ��5Z      �� $ ActualHeight�$ Size5�� �� 	Converter F	   @QAQCDesktopApplication.ValueConverter.MyApp.Tools.RatioConverter	   �� ConverterParameter$
 0.85��5[   D   5\      �� 5]      $��1��6   $��
-1 3 708 3q�6*   $��0 5 0 5q�6>   $
��13pt(�5^      ���	#FFBDDFE4
���   �$��0q�6O   $
 Tìm kiếm thông tin��5_      $ 
PrimaryMid=�5`      ��5a      �� *Filter+ �� UpdateSourceTrigger$ PropertyChanged=�.��6R   5b      5c      � 5d      -   5        $	 Size3��5d       $��3��6   $��4 5 4 5q�60   .+�5e      &
   System.Windows.Controls.DataGrid
  -   5         
 Name$ 
MyListView��5n   H   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5e        DataGridColumnHeaderStyle2 
  ColumnHeaderStyle# [ 5f       
  CanUserReorderColumns$ False��5g      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 	10 2 -5 2q�5h         ColumnHeaderPadding$ 	0 20 -2 2q�5i       
  AutoGenerateColumns$ False��5j       
  
IsReadOnly$
 True��6/    
  SelectionUnit$ FullRow=�6A     
  RowBackground  �	#FFD4D6EA! 
  AlternatingRowBackground
! �����$
��13pt(�5l      $��Visible=�5n      ��5e   @   �� *view+" �� SelectedItem" 5m      �� *
Selected+  5o      <   6QAQCDesktopApplication.ValueConverter.OrdinalConverter  OrdinalConverter  OrdinalColumnDataTemplate# �� RelativeSource$ �� Mode% �� AncestorType��%�   &	       &	      7    5p      62   �� 5q      .R�5r      �� $��Center=�5s   S   ��5r   (   �� # �� $$ FindAncestor=�% DataGridRow8   5s   S   5t      5u      & 
  Columns& 5v      4  .System.Windows.Controls.DataGridTemplateColumn  5w      ,  &System.Windows.Controls.DataGridColumn'   Width5  /System.Windows.Controls.DataGridLengthConverter$' 55 61   (   Header$	( STT��6<   )   CellTemplate#) [ 6I   5x      0  *System.Windows.Controls.DataGridTextColumn  5y      $	' 107 6-   $( MÃ MÁY��6P   1  +System.Windows.Controls.DataGridBoundColumn*   Binding* 69   �� *ID+6P     5z      $	' 127 6-   $( 
MÃ KHUÔN��6T   * 69   �� *moldId+6T     5{      $	' 177 6-   $( MÃ SẢN PHẨM��6X   * 69   �� *
product.id+6X     5|      $	' 200 6-   $( TÊN SẢN PHẨM��6Z   * 69   �� *product.name+6Z     5}      $	' 100 6-   $( NGÀY SẢN XUẤT��6R   * 69   �� *date+6R   4  .System.Windows.Controls.DataGridCheckBoxColumn  5~      $	' 100 61   $( THÔNG SỐ MÁY��6_   * 6=   �� *Thongsocaidat+6_     5      $	' 100 61   $( QUY TRÌNH HOẠT DỘNG��6b   * 6=   �� *Quytrinhhoatdong+6b     5�      $	' 100 61   $( NHÂN CÔNG ĐỨNG MÁY��6Z   * 6=   �� *
Nhancong+6Z     5�      $	' 100 61   $( NHIỆT ĐỘ��6Y   * 6=   �� *	Nhietdo+6Y   + J� InputBindings+ 5�      d� 5�      , d� MouseAction$, LeftDoubleClicke�6'   - �� Command- 5�      �� *DetailCommand+. �� CommandParameter. 5�      �� $ 
MyListView��$ SelectedItems�5�      5�      5�      5�      5�      5�      