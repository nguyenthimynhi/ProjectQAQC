   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:QAQCDesktopApplication.View.QAView"QAQCDesktopApplication.View.QAView  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5
      e7clr-namespace:QAQCDesktopApplication.Resource.Component)QAQCDesktopApplication.Resource.Component  5      ]3clr-namespace:QAQCDesktopApplication.ValueConverter%QAQCDesktopApplication.ValueConverter  5      8    2QAQCDesktopApplication.View.QAView.AddStandardView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:QAQCDesktopApplication.View.QAView     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools  5
      G	component7clr-namespace:QAQCDesktopApplication.Resource.Component  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      @local13clr-namespace:QAQCDesktopApplication.ValueConverter  5      -   5          >�Name$	  ASd��5   	   $	��680��5      $
��1060��6      MaterialDesignBody#���   5      $��Regular"�5   	   $
��13pt(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   $��Arial)�5   	   ���	#3F000000$
��15 7q�5   -   .��5      #  MaterialDesignThemes.Wpf.Card  
�������$
��20 5q�6-      UniformCornerRadius$ 0Q�6<   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=�5      $��0q�6B   .��5   
   �  � RowDefinitions 5      �� 5      $
��0.6* �6    �� 5      $
��1.8* �6    �� 5      $��12.2* �6    .+�5      � -   5         �Name$
 Size��5       $��0��6   ���	#66C8CBF7$��0 -5 0 5q�6E   .+�5      �� $��0��6   $��10.5pt(�6)    �� TextAlignment$ Center=�6;   $��0 5 0 0q�6R   $��Calibri)�6c   $;��5Tiêu chuẩn kiểm tra chất lượng sản phẩm��5       $
��Thin"�6D   �� 5!      $��Right=�6     CloseButton#��[ 65   
���iii�$��-5q�5$   .   ��5"      ��  �� Path$ ActualHeight�	 �� ElementName$
	 Size����5#      �� $ ActualWidth�$
	 Size��
 �� 	Converter
 F   @QAQCDesktopApplication.ValueConverter.MyApp.Tools.RatioConverter   �� ConverterParameter$ 0.025����5%      �� *CloseCommand+��5&      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�   Size 205'      5(      � 5)      -   5        $
 Open��5)       $��1��6   .+�5*      8   2QAQCDesktopApplication.Resource.Component.OpenFile  ��6%   �� $ ActualWidth�$
	 Open����5+      �� $ ActualHeight�$
	 Open��5,      � 5-      $��2��6    5.      �� 5/      $	��12* �6$   �� 50      $��6* �6$   .+�52      � $��0��6   .+�53      (  "System.Windows.Controls.WebBrowser  <   6QAQCDesktopApplication.ValueConverter.WebBrowserHelper
   Url 6!   �� *
TextFile+54      � 55      $��1��6   $
��35 0q�6$    � ColumnDefinitions 56      �� 57      $��3* �6+   �� 58      $
��0.1* �6+   �� 59      $��4* �6+   .+�5;      �� -   5         ��Name$ Size1��5;   H    �� Orientation$ Vertical=�6!   $��0��68   .+�5<      �� $��Kích thước��6$   $ Center=�66    �� Padding$ 0 4 0 0q�6M   ���	#FF2FB2D4
�������$
��31.2��5=   N   ��5>   $   �� $ ActualWidth�$	 Size1��� 5?       5@      �� 5A   "   $��3* �63   �� 5B   "   $��4* �63   �� 5C   "   $��4* �63   �� 5D   "   $
��auto �63   �� 5E   "   $
��auto �63   .+�5G      �� $��	20 2 10 3q�6F   $��0��6Z   $��Center=�6j   $��1q�5H   '   
�������$��0 3 0 1q�6N   ���	#FF2673BF �� Text 5G   '   �� *Namedimension+.@�5I   "   �� $��A��6/   �� 5J   "   $��B��6/   �� 5K   "   $��C��6/   �� 5L   "   $��D��6/   5M      �� 5N      $��0 1 0 2q�6B   $��10 3 4 1q�6T   $��1��6f   ���	#FF2673BF$��1q�5O   &   
�������$��Center=�6M   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Lower��5P   &   ��5N   &   �� *
Lowerbound+5P   &   �� 5Q      $��0 1 0 2q�6B   $��4 3 10 1q�6T   $��2��6f   ���	#FF2673BF$��1q�5R   &   
�������$��Center=�6M   $ Upper��5S   &   ��5Q   &   �� *
Upperbound+5S   &   �� 5T      $��3��6%   $	��-20q�65   ���	#FF1C8FAD$��0 2 5 -1q�6Z   +
  %MaterialDesignThemes.Wpf.ButtonAssist 
  CornerRadius$ 0��5U   )   $��0q�5V   )   $��28��6`   $��28��6k   ��5U   V     *Add+ 20��5V   =   �� *InsertCommand+6k   �� 5W      $��4��6%   $	��-20q�65   ���	#FF1C8FAD$��28��6Z   $��28��6f   $��5 2 0 -1q�6q   $ 0��5X   )   $��0q�5Y   )   ��5X   V     *Delete+ 20��5Y   =   �� *RemoveCommand+5Z      &   System.Windows.Controls.DataGrid  5[         RowBackground �	#FFECEDEF$��Center=�5\   7     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 5]         CanUserSortColumns$ False��5^         AutoGenerateColumns$ False��68      HeadersVisibility$
 None=�6T   -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 
50 4 -50 3q�5_      ��5[   #   �� *
Dimensions+   Columns 5`      0  *System.Windows.Controls.DataGridTextColumn  5a   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 89 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *name+6N     5b   "   $	 134 6T    65   �� *
lowerBound+6T     5c   "   $	 134 6T    65   �� *
upperBound+6T   5e      5f      � 5g      -   5        $ Size2��5g   +   $��2��6    5h      �� 5i      $	��31* �6,   �� 5j      $	��34* �6,   �� 5k      $��89.265 �6,   �� 5l      $	��28* �6,   .+�5n      �� $��Ngoại quan��6$   $ Center=�66   $ 3q�6M   ���	#FF2FB2D4
�������$��0��5o   N   ��5p   $   �� $ ActualWidth�$	 Size2��� 5q      $��1��6    5r      �� 5s   "   $��* �63   �� 5t   "   $
��auto �63   �� 5u   "   $��0.02* �63   �� 5v   "   $
��auto �63   .+�5x      �� $��0��6&   $��0 3 10 4q�66   
�������$��0 1 0 2q�6[   $��Center=�6m   
���   ����	#FF2673BF$��1q�5y   M   ��6a   �� *	AddItem+.��6z   .��5|   <   5}      � 5~      $��1��6#   .+�5   "   �� $	��-20q�6)   ���	#FF1C8FAD$��28��6N   $��28��6Z   $ 0��5�   )   $��0q�5�   )   ��5�   V     *Add+ 20��5�   =   �� *
AddCommand+5�      � 5�      $��3��6#   .+�5�   "   �� $	��-20q�6)   ���	#FF1C8FAD$��28��6N   $��28��6Z   $ 0��5�   )   $��0q�5�   )   ��5�   V     *Delete+ 20��5�   =   �� *DeleteCommand+5�      5�      7   1QAQCDesktopApplication.Resource.Component.ListBox  5�      $��2��6,   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�   "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5�   &       	EventName$  MouseDoubleClick��66   *  $Microsoft.Xaml.Behaviors.TriggerBase!   Actions.! 5�   *   -  'Prism.Interactivity.InvokeCommandAction  "   Command" 6D   �� *ImageCommand+5�   '   5�      �� 5�      $��Right=�6!   $ 0��5�      $��42��5�      $	��110��6)   $��3��65   ���	#FF2673BF$
��15pt(�5�   5   ���	#00000000$��30 -15 -35 0q�5�   5   # � ToolTip$8# 2Resource name: MaterialDesignRaisedLightDarkButton��5�      $
��LƯU��6Z     MaterialDesignRaisedButton#��[ 5�      ��5�      �� *SaveCommand+5�      5�      5�      5�      5�      5�      