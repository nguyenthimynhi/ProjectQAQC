   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:QAQCDesktopApplication.ViewQAQCDesktopApplication.View  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5      V RQAQCDesktopApplication.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Xclr-namespace:QAQCDesktopApplication.Core.ViewModel;assembly=QAQCDesktopApplication.Core%QAQCDesktopApplication.Core.ViewModel 6\   +    %QAQCDesktopApplication.View.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      5local)clr-namespace:QAQCDesktopApplication.View  5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      _	 [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools 	 5      h	viewmodelXclr-namespace:QAQCDesktopApplication.Core.ViewModel;assembly=QAQCDesktopApplication.Core 	 6\   -   5          >�Name$  Mlogin��5   	   $	��680��5
      $
��1000��6      MaterialDesignBody#���   5      $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���#E8EAF6$��Calibri)�5   	   .��5      � .+�5   
   # 	 MaterialDesignThemes.Wpf.Card  $
��20 5q�6   ���	#FF1D4780   UniformCornerRadius$ 0Q�6D   + 	 %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�5      ��5      ��  �� Path$ Height� �� ElementName$ Mlogin�� �� 	Converter F   @QAQCDesktopApplication.ValueConverter.MyApp.Tools.RatioConverter   �� ConverterParameter$
 0.49����5      �� $ Width�$ Mlogin��   $
 0.45��.��5      � 	 � RowDefinitions	 5      �� 5      $��2* �6$   �� 5      $��3* �6$   �� 5      $��3* �6$   �� 5       $��4* �6$   .+�5"      �� $��0��6   $
��25pt(�6)   
�������$��Center=�6L   $��
0 25 0 -10q�6i   �� 6~   .�6�   ĐĂNG NHẬP6�   6�   � 5#      $��1��6   
 � ColumnDefinitions
 5$      �� 5%      $��* �6+   �� 5&      $	��10* �6+   .+�5(      ' 	 !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountHardHat=�6.   $��0��6D   $��Center=�6T   $��Bottom=�6q   $��40��6�   $��40��6�   
�������6�   �� 5)      $
��18pt(�6   
�������$��1��6A   ) 	 #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��5*      $��Calibri)�6L    % !MaterialDesignFloatingHintTextBox#��[ 5,      
�������$��0 0 0 2q�5-   1   $��Center=�6K   ��5+      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�5-   K   5.      � 5/      $��2��6   
 50      �� 51      $��* �6+   �� 52      $	��10* �6+   .+�54        $ 	KeyChange=�6.   $��0��6?   $��Center=�6O   $��Bottom=�6l   $��40��6�   $��35��6�   
�������6�   G� 55      -   5         G�Name$ FloatingPassWordBox��57      $��1��55   "   $
��18pt(�62   
�������$ Mật khẩu��56      $��Calibri)�6G   $��0 0 0 2q�57   :   $��Center=�6T    ) %MaterialDesignFloatingHintPasswordBox#��[ 58      
�������*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5:      +  %Microsoft.Xaml.Behaviors.EventTrigger  5;         	EventName$ PasswordChanged��6-   *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5<   "   2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
   
  Command 68   �� *PasswordChangedCommand+ 
  CommandParameter 5=   $   �� $ FloatingPasswordBox��5>      5@      5A      � 5B      -   5         �Name$ Size1��5B   $   $��3��6   .+�5C      ��  " MaterialDesignRaisedDarkButton#��[ 6   ���	#FF1D6EBF$��0 9 0 5q�5D   4   $
��22pt(�6E   
������ $��Medium"�5G   7   + 	 %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��5H       � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��5I      $��Đăng Nhập��6U   ��5E      �� $ ActualHeight�$ Size1��   $
 0.65����5F      �� $ ActualWidth�$ Size1��   $
 0.45����5J      �� *LoggingCommand+5K      5L      5M      5N      5O      