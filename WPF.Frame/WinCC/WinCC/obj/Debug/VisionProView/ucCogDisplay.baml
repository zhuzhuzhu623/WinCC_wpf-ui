   M S B A M L   `   `   `  ����@  <WinCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WinCC.VisionProViewWinCC.VisionProView  5      i eCognex.VisionPro.Display.Controls, Version=61.1.0.0, Culture=neutral, PublicKeyToken=ef0f902af9dee505nQclr-namespace:Cognex.VisionPro.Display;assembly=Cognex.VisionPro.Display.ControlsCognex.VisionPro.Display 5      &     WinCC.VisionProView.ucCogDisplay   5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WinCC.VisionProView     5      aCogQclr-namespace:Cognex.VisionPro.Display;assembly=Cognex.VisionPro.Display.Controls     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MainWinBorder#���   5
   s   .��5      � -   5          �Name$  gridDisplayView��5      $��0 4 0 0q�6$    � RowDefinitions 5   
   �� 5      �� 5      $	��538 �6   .+�5   
   � $��1��6   .+�5      �� 7  1System.Windows.Forms.Integration.WindowsFormsHost  5      $��0��6      Child. 5      )  #Cognex.VisionPro.Display.CogDisplay  -   5        displayView��5   y   5      5      �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ btnPram��5      $��参数��6'   $��Center=�64   $	��Top=�6Q   $��80��6i   $��25��5        
DataButton#��[ 6#   5      �� 5      -   5        $ btnLed��5      $��灯光��6&   $��Center=�63   $	��Top=�6P   $��80��6h   $��25��5      #��[ 6"   5      5      � 5   
   -   5         �Name$ 	popupPram��5      $	��260��6$   $	��200��60    � 	StaysOpen .  $��Relative=�6O    � AllowsTransparency . $
��Fade=�6�   $��	15 15 0 0q�6�    � PlacementTarget 6d   �� 	 �� ElementName$	 gridDisplayView��.��5      �� 
���   �$��1q�6)     MainDialogBorder#���  6=   $	��260��6m   $	��130��6y   ._�5       �� .+�5!      �� $ 
Horizontal=�6!   $��Center=�6:   $��0 10 0 0q�6U   .+�5"      �� $��	对比度��6$     BaseTextBlock#��[ 6/   $��Center=�6W   
 �� Padding$
 10 0 0 0q�6t   �� 5#      -   5         ��Name$ txtContrast��5#   "     
TxtBoxBase#��[ 68     MainColorLineThree.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  6]   �� 5$      -   5         ��Name$ sliderContrast��5$   !    �� TickFrequency$ 8Q�69     MainControlsColors#���  6L    �� Orientation$ 
Horizontal=�6    �� TickPlacement$ BottomRight=�6�    � Minimum$ 0Q�6�    � Maximum$	 100Q�6�    �� IsSelectionRangeEnabled . $	��124��6�   $��2 0 0 0q�6�   $��20��6   �� IsSnapToTickEnabled . 6D  5%      �� 5&      $ 
Horizontal=�6!   $��Center=�6:   $��0 12 0 0q�6U   .+�5'      �� $��亮度��6$   #��[ 6.   $��Center=�6V   $
 10 0 0 0q�6s   �� 5(      -	   5        $ txtBrightness��5(   "   #��[ 69   # �  6^   �� 5)      -
   5        $ sliderBrightness��5)   !   $ 8Q�6;   #���  6O   $ 
Horizontal=�6�   $ BottomRight=�6�   $ 0Q�6�   $	 100Q�6�    . $	��124��6�   $��2 0 0 0q�6�   $��20��6   . 6E  5*      �� 5,      $ 
Horizontal=�6!   $��Center=�6:   $��0 12 0 0q�6U   .+�5-      �� $��曝光��6$   #��[ 6.   $��Center=�6V   $
 10 0 0 0q�6s   �� 5.      -   5        $ txtExposure��5.   "   #��[ 67   # �  6[   �� 5/      -   5        $ sliderExposure��5/   !   #���  69   $ 8Q�6k   $ 
Horizontal=�6~   $ BottomRight=�6�   $ 0Q�6�   $	 100Q�6�    . $	��124��6�   $��2 0 0 0q�6�   $��20��6
   . 6A  50      51      53      54      � 55   
   -   5        $ popupLed��55      $	��200��6"   $	��200��6.    . $
��Fade=�6V   .��56      �� 
���   �$��1q�6)   
����ح�$	��200��6T   $	��100��6`   58      59      5;      5<      