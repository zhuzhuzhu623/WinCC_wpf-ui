   M S B A M L   `   `   `  ����C  ?WinCC.Ui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WinCC.UiWinCC.Ui  5   	   i eCognex.VisionPro.Display.Controls, Version=61.1.0.0, Culture=neutral, PublicKeyToken=ef0f902af9dee505nQclr-namespace:Cognex.VisionPro.Display;assembly=Cognex.VisionPro.Display.ControlsCognex.VisionPro.Display 5	      E'clr-namespace:WinCC.Ui.Views.CameraViewWinCC.Ui.Views.CameraView  5
   	       WinCC.Ui.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WinCC.Ui     5   	   M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   R NWpf.Ui.Tray, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd66tray+http://schemas.lepo.co/wpfui/2022/xaml/tray  5   	   [CogQclr-namespace:Cognex.VisionPro.Display;assembly=Cognex.VisionPro.Display.Controls  5	      4local1'clr-namespace:WinCC.Ui.Views.CameraView  5
   	   -   5        $
��1000��5      $
��1920��6     � WindowState$  	Maximized=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�6'    � 	Resources 5       .  *NavigationViewSelectionIndicatorForeground �� Color��%/   &	        �� 5   
   $ #ffc080��5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��104 �6#   �� 5      .+�5       � .+�5!      ��   	MainColor#���  6    �� CornerRadius$ 10��6C   �� 5"      $��Laser��6   $��24(�6*   
�������$��Center=�6K   $��Center=�6h   5#        Wpf.Ui.Controls.TitleBar  5$      -   5          Name$ TitleBar��5'      $��1��5%      $��2��5&      	   Title$	  ��5(      $��24(�5)      $��0 0 0 0q�6   $��0q�5*      %
   CloseWindowByDoubleClickOnIcon
 . $��Center=�5+   (   $��Center=�6C      ShowMaximize .  5,      5-      � 50   
   $��1��6   $��0 0 0 0q�6   .+�51      $  Wpf.Ui.Controls.NavigationView  -   5          Name$ RootNavigation��52      $��1��53      $��0��6      PaneDisplayMode$ 
LeftFluent=�54         Header 55      #  Wpf.Ui.Controls.BreadcrumbBar  56      $��0q�57   
   $��20(�58   
   $��DemiBold"�59   
   $��0q�6    5<      �� 5B      $��Bottom=�6   $��4 0 0 10q�64   .+�5C      � $��96��6   $
��Left=�6"   .+�5D      ��   MainColorOpacity#���  6   $ 5��6N   �� 5E       �� Orientation$ 
Horizontal=�6!   $��Bottom=�6:   $��5 0 0 0q�6U   .+�5F      �� $��X:��6$   $��16(�6.   �� 5G      $�� ��6$   $��16(�6-   5H      5I      � 5J      $��96��6   $
��Left=�6"   $��0 2 0 0q�6=   .+�5K      �� #���  6   $ 5��6N   �� 5L      $ 
Horizontal=�6!   $��Bottom=�6:   $��5 0 0 0q�6U   .+�5M      �� $��Y:��6$   $��16(�6.   �� 5N      $�� ��6$   $��16(�6-   5O      5P      � 5Q      $��96��6   $
��Left=�6"   $��0 2 0 0q�6=   .+�5R      �� #���  6   $ 5��6N   �� 5S      $ 
Horizontal=�6!   $��Bottom=�6:   $��5 0 0 0q�6U   .+�5T      �� $��Z:��6$   $��16(�6.   �� 5U      $�� ��6$   $��16(�6-   5V      5W      � 5X      $��96��6   $
��Left=�6"   $��0 2 0 0q�6=   .+�5Y      �� #���  6   $ 5��6N   �� 5Z      $ 
Horizontal=�6!   $��Bottom=�6:   $��5 0 0 0q�6U   .+�5[      �� $��A:��6$   $��16(�6.   �� 5\      $�� ��6$   $��16(�6-   5]      5^      � 5_      $��96��6   $
��Left=�6"   $��0 2 0 0q�6=   .+�5`      �� #���  6   $ 5��6N   �� 5a      $ 
Horizontal=�6!   $��Bottom=�6:   $��5 0 0 0q�6U   .+�5b      �� $��B:��6$   $��16(�6.   �� 5c      $�� ��6$   $��16(�6-   5d      5e      � 5f      $��96��6   $
��Left=�6"   $��0 2 0 0q�6=   .+�5g      �� #���  6   $ 5��6N   �� 5h      $ 
Horizontal=�6!   $��Bottom=�6:   $��5 0 0 0q�6U   .+�5i      �� $��C:��6$   $��16(�6.   �� 5j      $�� ��6$   $��16(�6-   5k      5l      5m      5o      �� 5q   
   	 �� X1$	 300��6   	 �� Y1$ 20��6   	 �� X2$
 1200��6    	 �� Y2$ 20��6*    �� StrokeDashArray$	 1,1R�62   
���W�.�$��1��6Z   �� 5~   
   $
 1400��6   $ 37��6   $
 1450��6!   $ 2��6+   #���  63   $��3��6X   �� 5   
   $
 1450��6   $ 2��6   $
 1700��6    $ 2��6*   #���  62   $��3��6W   �� 5�   
   $
 1700��6   $ 2��6   $
 1750��6    $ 37��6*   #���  63   $��3��6X   �� 5�   
   $	 105��6   $ 37��6   $
 1400��6    $ 37��6*   #���  62   $��3��6W   �� 5�   
   $
 1750��6   $ 37��6   $
 1920��6!   $ 37��6+   #���  63   $��3��6X   �� 5�   
   $
 1400��6   $ 37��6   $
 1750��6!   $ 37��6+   #���  65   $��3��6Z   � 5�   
   $��
1220 0 0 0q�6   .+�5�      �� #���  6   $	��120��6?   $��28��6K   $ 5��6W   �� 5�      $��工作��6   
�������$��20(�67   $��Center=�6F   $��Center=�6c   5�      5�      5�      