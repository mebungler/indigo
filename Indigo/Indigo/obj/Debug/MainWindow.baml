   M S B A M L   `   `   `  ����A  =Indigo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:IndigoIndigo  5   	       Indigo.MainWindow   5   	   localclr-namespace:Indigo  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��400��6)    � Icon$ Images/Indigo-Logo.ico��5   	   $	��600��5   	   $	��400��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         Indigo.MainWindow �� 
TargetType �� Property �� Value �� 
TargetType   DarkBackgroundBrush � RowDefinitions  LighterBackgroundBrush	 � ColumnDefinitions  AccentBrush
 �� Orientation  ControlButton  CloseButton  MControlButton  
PlayButton ��Name&    Indigo.ExtensionToImageConvertor   Instance �� 	Converter  WhiteForegroundBrush�   �Indigo.BaseAttachedProperty`2[[Indigo.HasTextProperty, Indigo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] �� Mode ��Name
 � Tag �� UpdateSourceTrigger��%b
  '        7   7  7  7  7  7  7  7  7  7  7   7  7  7  �� 5   
   "  6   .�5      ��  � �� 5      �� 5      " �6&   .R�5      �� ._�5      � 8��   5   "   �� 5   &   $
��auto �64   6D   �� 5   &   $
��auto �64   6D   �� 5   &   $��* �64   6A   �� 5   &   $
��auto �64   6D   .+�5   "   �� 8�� ._�5   &   � 	 5   *   �� 5   .   6A   �� 5    .   6A   .+�5"   *   �� $��Indigo��64    5#   .   ���� 5$   2   '��       " ��68   .�5%   6   ��  � ��8  6z   �� 5&   6    � ��$ 20(�6Q   6^   �� 5'   6    �@��Padding$ 5q�6P   6\   �� 5(   6    � ��$ 5q�6O   6[   5)   3   5*   /   5+   +   �� 5,   *   $��1��66   $��Right=�6F   $
 
Horizontal=�6b   .+�5-   .   �� 8�� $	����6]   ��6p   �� *MinimizeCommand+6�   �� 5.   .   8�� $	����6]   ��6p   �� *MaximizeCommand+6�   �� 5/   .   8�� $	����6Z   ��6m   �� *ExitCommand+50   /   51   +   52   '   53   #   �� 55   "   $��1��6)   ._�56   &   �� $��Center=�61   $
 
Horizontal=�6N   .+�57   *   �� $��30,10,10,10q�6V   8�� $	����6�   ��61   �� *PreviousCommand+6�   �� 58   *   $��10q�6Q   8�� $	����6�   ��61   �� *PlayCommand+6�   �� 59   *   $��10 10 30 10q�6R   8�� $	����6�   ��61   �� *NextCommand+6�   5:   '   5;   #   �� 5=   "   $��2��6)   ._�5>   &   � .+�5?   *   �� $ MainList��62   ��6D   �� *Items+��5@   .   �� 5A   2   .R�5B   6   �� $
 
Horizontal=�6A   .+�5C   :   �� ��6@   �� *Type+# Z 6�   �� 5D   :   8��	 $��Center=�6�   ��6D   �� *Name+6�   5E   7   5F   3   ��5H   .   �� 5I   2   " ��68   .�5J   6   ��  � ��8 
 6�   �� 5K   6    � ��$ 0q�6X   6d   �� 5L   6    �@ Value 6d   �� *	HasText+�� 5M   6    � ��$ Hidden=�6s   6�   �� 5N   6    �@��SelectedItem 6U   �� *SelectedItem+$ TwoWay=�6�   5O   3   5Q   +   5R   '   5S   #   �� 5U   "   $��3��6)   ._�5V   &   � 	 5W   *   �� 5X   .   $
��auto �6?   6N   �� 5Y   .   6A   .+�5[   *   �� $
 
Horizontal=�65   .+�5\   .   �� $��10q�6U   $��25(�6a   $	����6o   8�� ��65   �� *LoadCommand+6�   �� 5]   .   $��10q�65   $��25(�6A   $	����6O   8�� 6�   �� 5^   .   $��10q�65   $��25(�6A   $�� ��6O   8�� 6�   5_   +   �� 5`   *   $ QuickSearchTB��62   $ Quick search ...��6�   $��1��6�   ��6I   �� *QuickSearchString+$ TwoWay=�$ PropertyChanged=�.��6�   5a   +   5b   '   5c   #   5d      5e      5f      5h      5i      5j      '  !System.Windows.Shell.WindowChrome   WindowChrome 5k        5l   
   -   5        WindowChrome��   ResizeBorderThickness$ 6q�5l   -      CaptionHeight$ 30Q�5m         CornerRadius$ 0��5n         GlassFrameThickness$ 0q�5o      5q      