   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   J FSuperTextEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SuperTextEditorSuperTextEditor 5   	       SuperTextEditor.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   /localclr-namespace:SuperTextEditor     5   	   -   5          � Title$  Super text editor��5
   	   $	��450��6#   $	��800��60   .��5      � .+�5   
   #   Xceed.Wpf.Toolkit.ColorPicker  -   5        $��colorPicker��5      $��
156,21,0,0q�6h   $
��Left=�6|   $��87��6�   $��26��6�   $	��Top=�6�   �� 5   
   -   5        $��userText��5      $��Italic)�6&   $��	0,47,0,-4q�6:   . �5      /� .T�5      J� .*�6   5      5      5      o� 5   
   $��21��6   $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� -   5        $	��New��5      6(   m� 5      -   5        $
��Open��5      6)   m� 5      -   5        $��Save as��5      6,   �� 5      m� 5      -   5        $��Print��5      6*   �� 5      m� 5      -   5        $
��Exit��5      6)   5      m� 5      $
��Edit��6   .@�5      m� $
��Copy��6    m� Command$ ApplicationCommands.Copy��6)   m� 5      $��Paste��6   $ ApplicationCommands.Paste��6*   m� 5       $	��Cut��6   $ ApplicationCommands.Cut��6(   �� 5!      m� 5"      $��
Select all��6   $# ApplicationCommands.SelectAll��6/   �� 5#      m� 5$      $
��Undo��6   $ ApplicationCommands.Undo��6)   m� 5%      $
��Redo��6   $ ApplicationCommands.Redo��6)   5&      5'      �� 5(   
   -	   5        $
��Left=�5(   .   $��
304,21,0,0q�6I   $	��Top=�6]   $��30��6u   $��26��6�   .��5)      �� $��36��6   $��25��6$   .+�5*      �� $��icons\underline.png��6   $��20��65   $��0,0,12,0q�6A   5+      5,      �� 5-   
   -
   5        $
��Left=�5-   +   $��
274,21,0,0q�6F   $	��Top=�6Z   $��30��6r   $��26��6}   .��5.      �� $��36��6   $��20��6$   .+�5/      �� $��icons\italic.png��6   $��20��62   $��0,0,10,0q�6>   50      51      �� 52   
   -   5        $
��Left=�52   )   $��
244,21,0,0q�6D   $	��Top=�6X   $��30��6p   $��26��6{   .��53      �� $��36��6   $��20��6$   .+�54      �� $��icons\bold.png��6   $��20��60   $��0,0,10,0q�6<   55      56      �� 57   
   -   5        $��fontFamilyComboBox��57      $
��Left=�6-   $��0,21,0,0q�6H   $	��Top=�6Z   $	��111��6r   $��26��6~   6�   �� 58   
   -   5        $��fontSizeComboBox��58      $
��Left=�6+   $��26��6F   $��
111,21,0,0q�6R   $	��Top=�6f   $��45��6~   6�   59      5:      