   M S B A M L   `   `   `  ����Q  MQAQCDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:QAQCDesktopApplication.Resource.Component)QAQCDesktopApplication.Resource.Component  5      u?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools1QAQCDesktopApplication.ValueConverter.MyApp.Tools  5      :    4QAQCDesktopApplication.Resource.Component.MenuButton   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:QAQCDesktopApplication.Resource.Component     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Ktools?clr-namespace:QAQCDesktopApplication.ValueConverter.MyApp.Tools  5      -   5          >�Name$
  root��5	      $��Arial)�5
      $��DemiBold"�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      $��
0 0 -0.5 0q�5   7   .��5      � ��6   ��  �� ElementName$
 root�� �� Path$ BackgroundBTMenu� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��25* �6   .+�5   
   �� $��0��6   $��0 0 0 0q�6U   ��6$   �� $
 root��$ Selected�6U   �� 5   
   -   5         ��Name$ 
MainButton��5      $��1��6%   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowEdges$
 None=�5      	   ShadowDepth$	 Depth0=�5      $��0q�5      $��Center=�5         
MenuButton#��[  5      ��5      �� $ Height�$
 root����5      �� $ BoderBrushBTMenu�$
 root����5       � 5!      $	��-20q�6   .+�5"      �� 
 �� Orientation$
 
Horizontal=�6!   y�5#   !   �� $
 root��$ 
Animation1�   BooleanToVisibilityConverter �� 	Converter# [ .+�5$      '  !MaterialDesignThemes.Wpf.PackIcon  $��Right=�5&      $��5 0 0 0q�69   $��Center=�5'      ��5$   2   �� $ ActualWidth�$ 
MainButton�� F   @QAQCDesktopApplication.ValueConverter.MyApp.Tools.RatioConverter   �� ConverterParameter$	 0.2����5%      �� $ ActualHeight�$
 root����5(      �� $ ForegroundPackicon�$
 root��   Kind 5)      �� *	IconValue+$
 root��5*      �� 5+      -   5         ��Name$ ContentValue��5+   7   $��	10 0 -2 0q�6$   $
��Left=�5,      $��Center=�64   $
��17pt(�6O   ��5+   M   �� $ ActualWidth�$ 
MainButton��   $	 0.7����5-      �� $ ForegroundText�$
 root����5.      �� $ ContentText�$
 root��5/      �� 50      $
 
Horizontal=�6!   y�51   !   �� $
 root��$ 
Animation2�# [ .+�52      �� $��5 0 15 0q�6$    �� TextAlignment$ Right=�53      $��Center=�6/   $
��17pt(�55      ��52   6   �� $ ActualWidth�$ 
MainButton��   $
 0.65����54      �� $ ForegroundText�$
 root����55   )   �� $ ContentText�$
 root��  56      $��Right=�58      $��Center=�59      ��56   2   �� $ ActualWidth�$ 
MainButton��   $	 0.2����57      �� $ ActualHeight�$
 root����5:      �� $ ForegroundPackicon�$
 root�� 5;      �� *	IconValue+$
 root��5<      5=      5>      5@      5A      5B      