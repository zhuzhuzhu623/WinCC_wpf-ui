   M S B A M L   `   `   `  ����D  @Translate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Translate	Translate  5   	        Translate.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Translate     5   	   c _MaterialDesignThemes.MahApps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a<md1http://materialdesigninxaml.net/winfx/xaml/themes   60   Y UPrism.Unity.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59S	 OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 6p   -   5          � Title$  翻译��5   	   $	��500��6   $	��800��6!   
�������! 	 Prism.Mvvm.ViewModelLocator   AutoWireViewModel$
 True��6W   .��5	      � .+�5
   
   ��  *  &MaterialDesignNavigationRailTabControl#��[  6   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryDark=�6W   
������ .@�5      �� $��首页��6    ' #MaterialDesignNavigationRailTabItem#��[ 6"   $��50��6`   .��5      �  � RowDefinitions 5      �� 5      $��50 �6(   �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��10 0 0 0q�6:   .+�5      �� -   5        $��cbxFrom��5   #   $��70��62   $��25��6=   $��楷体)�6I   $��16(�6Y   6g   �� 5      $��/Resoure/goto.png��6    $��20��6;   $��20��6F   $��	10 0 10 0q�6R   �� 5      -   5        $��cbxTo��5   #   $��70��60   $��25��6;   $��楷体)�6G   $��16(�6W   6e   5      � 5      $��1��6    5      �� 5      �� 5      $��50 �6,    � ColumnDefinitions 5      �� 5      �� 5      .+�5      ]� .+�5       �� $��0q�6%    �� CornerRadius$ 5��60   
�������$��0q�6V   �� 5!      -   5         ��Name$ txtInput��5!   &   
�������$��	10 0 10 0q�6N   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 输入单词或长句��6b   $��楷体)�6   .  (MaterialDesignThemes.Wpf.TextFieldAssist	   UnderlineBrush
	 �����$��22(�6�   $��
ExtraBlack"�6�   $��0q�6�   
 �� TextWrapping$

 Wrap=�6�   .��6-  5"      5#      ]� 5$      $��1��6$   .+�5%      �� $��0q�6%   $ 5��60   
�������$��0q�6V   �� 5&      -   5        $ 	txtResult��5&   &   
�������$��	15 0 10 0q�6M   $ 结果��6a   $��Arial)�6y   
	 �����$��22(�6�   $��
ExtraBlack"�6�   $��0q�6�   $

 Wrap=�6�   .��6  5'      5(      � 5*      $��1��6   $��Right=�6,   .+�5+      �� $ 
Horizontal=�6)   .+�5,   "   �� -   5        $��btnClear��5,   )   $��80��69   
����������#7a8087$��清空��6m   
���   �$��0 0 10 0q�6�   6�   �� 5-   "   -   5        $��btnTranslate��5-   *   $��80��6>   
���  ��
���  ��$��翻译��6l   
�������6�   5.      5/      �� 50      	 �� X1$	 400��6   	 �� Y1$ 0��6(   	 �� X2$	 400��6/   	 �� Y2$	 450��68   
���   �$��1��51       �� StrokeDashArray$	 3 3R�52      $��2��6   $��	-25 0 0 0q�6,   53      54      55      �� 56      $��文件��6   #��[ 6#   $��50��6a   59      5:      5=      5>      