   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source $   MenuScrollingVisibilityConverter  	DownArrow  UpArrow  
RightArrow  	Checkmark  MenuScrollButton �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels	 �� 
ResourceId
 �� TypeInTargetAssembly � ColumnDefinitions � RowDefinitions �� CanContentScroll �� LineUpCommand �� RelativeSource `� 	Converter `� ConverterParameter �� FallbackValue �� Path  Menu.Static.Foreground �� LineDownCommand ��Name F�Name �� Triggers P� Value P� Property �� 
TargetName ! MenuItem.Highlight.Background  MenuItem.Highlight.Border 	 Menu.Disabled.Foreground ]� 
Conditions �� Property �� Value *
 &MenuItem.Highlight.Disabled.Background & "MenuItem.Highlight.Disabled.Border �Name � AllowsTransparency  � PlacementTarget! �� ElementName  Menu.Static.Background  Menu.Static.Border" �� Padding# ��Name$ �� ClearTypeHint% ��Name  Menu.Static.Separator& ��Name-   'System.Windows.Input.KeyboardNavigation'    DirectionalNavigation( � IsSharedSizeScope)    TabNavigation* P� 
SourceName+ z� SharedSizeGroup   MenuItem.Selected.Background  MenuItem.Selected.Border, ��Name- J� Opacity. m� InputGestureText/ � HorizontalOffset0 � VerticalOffset1 �� AncestorType2 �� Triggers�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5        5      �� 5   
   $ Colors.xaml?�6   %�3  &	        &	      &	 @     &	 m     &	 �     &	     (�� Z    5      $	 MenuScrollViewer��"
 �)7  7   7  7  7  7   7  7  (�� �    5I      $	 TopLevelItemTemplateKey��"
 m�)7  7  7  7  7 	 7 	 7 
 7  (�� j    5o      $	 TopLevelHeaderTemplateKey��"
 m�)7  7  7  7  7  7  7 	 7 	 (�� �    5�      $	 SubmenuItemTemplateKey��"
 m�)7  7  7  7  7  7  7 	 7 	 7 
 7  (�� w     5�      $	 SubmenuHeaderTemplateKey��"
 m�)7  7  7  7  7  7  7  7  7  7 	 7 	 7 	 'm� �,    7  7  7  7  l� 5      6'   �5      M 0,0 L 3.5,4 L 7,0 Z�68   �5      M 0,4 L 3.5,0 L 7,4 Z�66   �5      M 0,0 L 4,3.5 L 0,7 Z�69   �5      UQF1 M 10.0,1.2 L 4.7,9.1 L 4.5,9.1 L 0,5.2 L 1.3,3.5 L 4.3,6.1L 8.3,0 L 10.0,1.2 Z�6t   �� 5      " ��68    6%   Z� .�5   
   ��  �@��	ClickMode$ Hover=�6&   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $ templateRoot��6   
������ $��1q�6L   
������ $
 true��6z   ._�5      �� $��Center=�6+   $��6q�6H   $��Center=�6S   5      5      5      5      �� 5      " ��6�    6w   Z� .�5   
   ��  � ��$ Hidden=�6:   �� 5   
    � ��$
 Auto=�68   �� 5   
    � �� 5       �� 5!      " ��6"   .R�5"      � $
 true��6    5#      �� 5$      $��* �6/    5&      �� 5'      $
��Auto �6,   �� 5(      $��* �6,   �� 5)      $
��Auto �6,   .+�5+      �� $��0��6!   $��1��61   ._�5,      �� # z��65   #��z��6k   5-      �� 5.      #��Z 6'   $��0��6�   $|�false��6�   $��0��6�   8��  ��6T   ��  �� *TemplatedParent+y�5/      `� 50   "   8  $ 0��6m   $ Visibility.Collapsed��6�   .1�51   &   �� $) #ComputedVerticalScrollBarVisibility�6.    6Y   �� *TemplatedParent+�� 52   &   $ VerticalOffset�6.    6D   �� *TemplatedParent+�� 53   &   $ ExtentHeight�6.    6B   �� *TemplatedParent+�� 54   &   $ ViewportHeight�6.    6D   �� *TemplatedParent+55   #   .��57      F� 8�� 8�� 6C   58      �� 59      #��Z 6'   $��0��6�   $|�false��6�   $��2��6�   8�� ��6V   ��  �� *TemplatedParent+y�5:      `� 5;   "   8  $	 100��6m   $ Visibility.Collapsed��6�   .1�5<   &   �� $) #ComputedVerticalScrollBarVisibility�6.    6Y   �� *TemplatedParent+�� 5=   &   $ VerticalOffset�6.    6D   �� *TemplatedParent+�� 5>   &   $ ExtentHeight�6.    6B   �� *TemplatedParent+�� 5?   &   $ ViewportHeight�6.    6D   �� *TemplatedParent+5@   #   .��5B      F� 8�� 8�� 6E   5C      5D      5E      5G      5H      �� 5I      " m�6�   .R�5J   
   �� $ templateRoot��6   #��z��6'   #��z��6Q   #��z��6�   $
 true��6�   ._�5K      � $��Center=�6    5L      �� 5M      $
��Auto �6'   �� 5N      $
��Auto �6'   .+�5P      �� $
 Icon��6#   $
��Icon��61   $��Center=�6F   $��16��6c   $��3q�6o   # z 6z   $��Center=�6�   $��16��6�   F� 5Q      $ 
GlyphPanel��6   8��  $��LeftToRight=�6M   8�� $��3q�6�   $��Center=�6�   $y�	Collapsed=�6�   �� 5R      $��Header��6#   $��1��6:   #��z��6J   $
��True��6m   # z 6�   5S      5T       5U   
   P� 5V       6&   Z�  �@m�Icon. �5W      �� $
 Icon��6/    � y�$ 	Collapsed=�6A   5X      P� 5Y       �@m�	IsChecked$
 true��6+   . �5Z      �� $ 
GlyphPanel��6/    � y�$ Visible=�6G   �� 5[      $
 Icon��6/    � y�$ 	Collapsed=�6A   5\      P� 5]       �@m�IsHighlighted$
 True��6/   . �5^      �� $ templateRoot��6/   8   � ��6I   �� 5_      $ templateRoot��60   8   � ��6J   5`      P� 5a       � {�$ False��6+   . �5b      �� $ templateRoot��6;   8   � ��6U   �� 5c      $ 
GlyphPanel��6)   8   � ��6A   5d      ]� 5e       5f      �� 5g       �@m�IsHighlighted$
 True��69   �� 5h       � {�$ False��65   ./�5j      �� $ templateRoot��6/   8   � ��6I   �� 5k      $ templateRoot��60   8   � ��6J   5l      5n      �� 5o      " m�6�   .R�5p   
   �� $ templateRoot��6   #��z��6'   #��z��6Q   #��z��6�   $
 true��6�   ._�5q      � $��Center=�6    5r      �� 5s      $
��Auto �6'   �� 5t      $
��Auto �6'   .+�5v      �� $
 Icon��6#   $
��Icon��61   $��Center=�6F   $��16��6c   $��3q�6o   # z 6z   $��Center=�6�   $��16��6�   $y�	Collapsed=�6�   F� 5w      $ 
GlyphPanel��6   8��  $��LeftToRight=�6M   #��z��6i   $��3q�6�   $��Center=�6�   $y�	Collapsed=�6�   �� 5x      $��Header��6#   $��1��6:   #��z��6J   $
��True��6m   # z 6�   � 5y      $ 
PART_Popup��6   $
 true��6,   $|�false��6F   $��Bottom=�6�   #��� -�6�   ��6X   �� *IsSubmenuOpen+ �� *TemplatedParent+  6  �� $! templateRoot��.��5z      �� $ SubMenuBorder��6   8�� $��1q�6i   8�� $" 2q�6�   ._�5{      �� $# SubMenuScrollViewer��6'   ��6D   C� *�� $	 MenuScrollViewer��"
 �+.��5|      � $$ Enabled=�6#   .+�5}   "   �� $
��Left=�6)   $��0��6D   $	��Top=�6O   $��0��6g   .+�5~   &   �� $% 
OpaqueRect��60   ��6D   �� *
Background+$! SubMenuBorder����6{   �� *ActualHeight+$! SubMenuBorder����6�   �� *ActualWidth+$! SubMenuBorder��5   #   �� 5�   "   $% Separ��6,   8�� $
��Left=�6i   $��29,2,0,2q�6�   $��1��6�   �� 5�   "   $& ItemsPresenter��61   $' Cycle=�6I   $
( true��6z   # z 6�   $) Cycle=�6�   5�      5�      5�      5�      5�      5�       5�   
   P� 5�      " �@m�IsSuspendingPopupAnimation$
 true��6<   . �5�      �� $ 
PART_Popup��63    � ��$
 None=�6K   5�      P� 5�       6&   Z�  �@m�Icon. �5�      �� $
 Icon��6/    � y�$ 	Collapsed=�6A   5�      P� 5�       �@m�	IsChecked$
 true��6+   . �5�      �� $ 
GlyphPanel��6/    � y�$ Visible=�6G   �� 5�      $
 Icon��6/    � y�$ 	Collapsed=�6A   5�      P� 5�       �@m�IsHighlighted$
 True��6/   . �5�      �� $ templateRoot��6/   8   � ��6I   �� 5�      $ templateRoot��60   8   � ��6J   5�      P� 5�       � {�$ False��6+   . �5�      �� $ templateRoot��6;   8   � ��6U   �� 5�      $ 
GlyphPanel��6)   8   � ��6A   5�      P� 5�      $* SubMenuScrollViewer��6?    � ��$ false��6`   . �5�      �� $ 
OpaqueRect��6/    6G   �� *VerticalOffset+$! SubMenuScrollViewer�� �@��Top�� 5�      $ 
OpaqueRect��60    6H   �� *HorizontalOffset+$! SubMenuScrollViewer�� �@��Left5�      5�      �� 5�      " m�6   .R�5�   
   �� $ templateRoot��6   #��z��6'   #��z��6Q   #��z��6�   $��22��6�   $
 true��6�   ._�5�      � $��-1q�6    5�      �� 5�      $��22��6'   $+ MenuItemIconColumnGroup��65   $
��Auto �6_   �� 5�      $��13 �6'   �� 5�      $��* �6'   �� 5�      $��30 �6'   �� 5�      $+ MenuItemIGTColumnGroup��6'   $
��Auto �6P   �� 5�      $��20 �6'   .+�5�      �� $
 Icon��6#   $
��Icon��61   $��Center=�6F   $��16��6c   $��3q�6o   # z 6z   $��Center=�6�   $��16��6�   �� 5�      $ 
GlyphPanel��6   8��  $��1q�6h   8�� $}�False��6�   $��Center=�6�   $��22��6�   $��-1,0,0,0q�6�   $��Center=�6  $y�Hidden=�6  $��22��63  ._�5�      F� $ Glyph��6   8�� $��LeftToRight=�6L   8�� $��11��6�   $��10��6�   5�      �� 5�      $ menuHeaderContainer��6#   $��Header��6@   $��2��6W   $
��Left=�6g   #��z��6�   $
��True��6�   # z 6�   $��Center=�6�   �� 5�      $, menuGestureText��6   $��4��65   #��z��6E   $	- 0.7Q�6h   #��z. 6v   $��Center=�6�   5�      5�       5�   
   P� 5�       6&   Z�  �@m�Icon. �5�      �� $
 Icon��6/    � y�$ 	Collapsed=�6A   5�      P� 5�       �@m�	IsChecked$
 True��6+   . �5�      �� $ 
GlyphPanel��6/    � y�$ Visible=�6G   �� 5�      $
 Icon��6/    � y�$ 	Collapsed=�6A   5�      P� 5�       �@m�IsHighlighted$
 True��6/   . �5�      �� $ templateRoot��6/   8   � ��6I   �� 5�      $ templateRoot��60   8   � ��6J   5�      P� 5�       � {�$ False��6+   . �5�      �� $ templateRoot��6;   8   � ��6U   �� 5�      $ Glyph��6)   8   � ��6<   5�      ]� 5�       5�      �� 5�       �@m�IsHighlighted$
 True��69   �� 5�       � {�$ False��65   ./�5�      �� $ templateRoot��6/   8   � ��6I   �� 5�      $ templateRoot��60   8 	  � ��6J   5�      5�      �� 5�      " m�6�   .R�5�   
   �� $ templateRoot��6   #��z��6'   #��z��6Q   #��z��6�   $��22��6�   $
 true��6�   ._�5�      � $��-1q�6    5�      �� 5�      $��22��6'   $+ MenuItemIconColumnGroup��65   $
��Auto �6_   �� 5�      $��13 �6'   �� 5�      $��* �6'   �� 5�      $��30 �6'   �� 5�      $+ MenuItemIGTColumnGroup��6'   $
��Auto �6P   �� 5�      $��20 �6'   .+�5�      �� $
 Icon��6#   $
��Icon��61   $��Center=�6F   $��16��6c   $��3q�6o   # z 6z   $��Center=�6�   $��16��6�   �� 5�      $ 
GlyphPanel��6   8��  $��1q�6i   8�� $��22��6�   $��-1,0,0,0q�6�   $��Center=�6�   $y�Hidden=�6�   $��22��6  ._�5�      F� $ Glyph��6   #���  6*   $��LeftToRight=�6M   8�� $��11��6�   $��9��6�   5�      �� 5�      $��Header��6#   $��2��6:   $
��Left=�6J   #��z��6e   $
��True��6�   # z 6�   $��Center=�6�   �� 5�      $��4��6   #��z��6,   $	- 0.7Q�6O   #��z. 6]   $��Center=�6�   F� 5�      $ 
RightArrow��6   $��5��6+   8�� 8�� $
��Left=�6�   $��10,0,0,0q�6�   $��Center=�6�   � 5�      $ 
PART_Popup��6   $
 true��6,   $|�false��6F   $/ -2��6X   $��Right=�6�   #��� -�6�   $0 -3��6'  ��6n   �� *IsSubmenuOpen+ �� *TemplatedParent+.��5�      �� $ SubMenuBorder��6   8�� $��1q�6i   8�� $" 2q�6�   ._�5�      �� $# SubMenuScrollViewer��6'   ��6D   C� *�� $	 MenuScrollViewer��"
 �+.��5�      � $$ Enabled=�6#   .+�5�   "   �� $
��Left=�6)   $��0��6D   $	��Top=�6O   $��0��6g   .+�5�   &   �� $% 
OpaqueRect��60   ��6D   �� *
Background+$! SubMenuBorder����6{   �� *ActualHeight+$! SubMenuBorder����6�   �� *ActualWidth+$! SubMenuBorder��5�   #   �� 5�   "   8�� $
��Left=�6Z   $��29,2,0,2q�6u   $��1��6�   �� 5�   "   $& ItemsPresenter��61   $' Cycle=�6I   $
( true��6z   # z 6�   $) Cycle=�6�   5�      5�      5�      5�      5�      5�       5�   
   P� 5�      " �@m�IsSuspendingPopupAnimation$
 true��6<   . �5�      �� $ 
PART_Popup��63    � ��$
 None=�6K   5�      P� 5�       6&   Z�  �@m�Icon. �5�      �� $
 Icon��6/    � y�$ 	Collapsed=�6A   5�      P� 5�       �@m�	IsChecked$
 True��6+   . �5�      �� $ 
GlyphPanel��6/    � y�$ Visible=�6G   �� 5�      $
 Icon��6/    � y�$ 	Collapsed=�6A   5�      P� 5�       �@m�IsHighlighted$
 True��6/   . �5�      �� $ templateRoot��6/    � ��
 ���� 6I   �� 5�      $ templateRoot��60   8   � ��6J   5�      P� 5�       � {�$ False��6+   . �5�      �� $ templateRoot��6;   8 	  � ��6U   �� 5      $ Glyph��6)   8 
  � ��6<   �� 5     $ 
RightArrow��6)   8   � ��6A   5     P� 5     $* SubMenuScrollViewer��6?    � ��$ false��6`   . �5     �� $ 
OpaqueRect��6/    6G   �� *VerticalOffset+$! SubMenuScrollViewer�� �@��Top�� 5     $ 
OpaqueRect��60    6H   �� *HorizontalOffset+$! SubMenuScrollViewer�� �@��Left5     5     �� 5	     " m�6   .�5
  
   ��  � �� 67   �� *HorizontalContentAlignment+ �� "1 ���� 5  
    � �� 65   �� *VerticalContentAlignment+ �� "1 ���� 5  
    � ��
 ���� 6'   �� 5  
    � ��
 ���� 6(   �� 5  
    � ��$ 1q�6,   �� 5  
    �@��PanningMode$
 Both=�65   �� 5  
    �@��IsFlicksEnabled$ False��63   �� 5  
    � �� 6%   C� *�� $	 SubmenuItemTemplateKey��"
 m�+2 5  
   P� 5      �@m�Role$ TopLevelHeader=�6&   . �5     ��  � ��
 ���� 6/   �� 5      � ��
 ���� 60   �� 5      � ��8   6/   �� 5      � �� 6-   C� *�� $	 TopLevelHeaderTemplateKey��"
 m�+�� 5      � ��$	 6,0q�6,   5     P� 5      �@m�Role$ TopLevelItem=�6&   . �5     ��  � ��8  6/   �� 5      � ��8  60   �� 5      � ��8  6/   �� 5      � �� 6-   C� *�� $	 TopLevelItemTemplateKey��"
 m�+�� 5      � ��$	 6,0q�6,   5      P� 5!      �@m�Role$ SubmenuHeader=�6&   . �5"     ��  � �� 6-   C� *�� $	 SubmenuHeaderTemplateKey��"
 m�+5#     5%     5(     