   M S B A M L   `   `   `  ����Y  UDatabaserUppgift1VSTuanMinhLuu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:DatabaserUppgift1VSTuanMinhLuuDatabaserUppgift1VSTuanMinhLuu  5   	   3    -DatabaserUppgift1VSTuanMinhLuu.LoggedInScreen   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:DatabaserUppgift1VSTuanMinhLuu     5   	     � Title$  LoggedInScreen��5   	   $	��450��6    $	��800��6-   .��5	      � ��5
   
   �� 5       �� ImageSource$ /parking.png��6    �� Opacity$	 0.5Q�64   .+�5   
   �� -   5         ��Name$ 
rentedCars��5      $
��Left=�6&   $	��121��6A   $��
410,69,0,0q�6N   $	��Top=�6b   $	��180��6z   6�   �� 5   
   -   5        $ 
carsToRent��5      $
��Left=�6&   $	��121��6A   $��	23,69,0,0q�6N   $	��Top=�6a   $	��180��6y   6�   �� 5   
   -   5         ��Name$ 
rentButton��5      $��Rent car��6%   $
��Left=�68   $��
23,221,0,0q�6S   $	��Top=�6g   $	��138��6   $��Malgun Gothic)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ returnButton��5      $��
Return car��6'   $
��Left=�6<   $��410,221,0,0q�6W   $	��Top=�6l   $	��138��6�   $��Malgun Gothic)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ changePasswordButton��5      $��Change password��6/   $
��Left=�6I   $��646,132,0,0q�6d   $	��Top=�6y   $	��144��6�   $��Malgun Gothic)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ editInfoButton��5      $��Edit your contact details��6)   $
��Left=�6M   $��
646,94,0,0q�6h   $	��Top=�6|   $��Malgun Gothic)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ logoutButton��5      $��Logout��6'   $
��Left=�68   $��
646,57,0,0q�6S   $	��Top=�6g   $	��144��6   $��Malgun Gothic)�6�   $
��Bold"�6�   6�   �� 5   
   -   5         ��Name$ carInfoLabel��5      $�� ��6&   $
��Left=�61   $��
23,256,0,0q�6L   $	��Top=�6`   $	��159��6x   $	��180��6�   $
��Bold"�6�   $��Malgun Gothic)�6�   $��16(�6�   �� 5   
   -	   5         ��Name$ 	searchbar��5      $
��Left=�6%   $��	23,32,0,0q�6@    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��180��6   6�   �� 5   
   -
   5         ��Name$ addDetailsPanel��5      	 J� Opacity$
	 0.95Q�6.   
�������.+�5      � $	��435��6   .+�5      �� -   5        $ lastnameInput��5      $
��Left=�61   $��
340,71,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5      -   5        $ 
emailInput��5      $
��Left=�6.   $��152,266,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5      -   5        $ countryInput��5      $
��Left=�60   $��340,200,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5      -   5        $ 	cityInput��5      $
��Left=�6-   $��152,200,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5      -   5        $ zipCodeInput��5      $
��Left=�60   $��340,137,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5      -   5        $ addressInput��5      $
��Left=�60   $��152,137,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5      -   5        $ firstnameInput��5      $
��Left=�62   $��
152,71,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5      $��
First name��6   $
��Left=�6-   $��
152,45,0,0q�6H   $	��Top=�6\   $��Malgun Gothic)�6t   �� 5       $��Country��6   $
��Left=�6*   $��340,174,0,0q�6E   $	��Top=�6Z   $��Malgun Gothic)�6r   �� 5!      $��Zip code��6   $
��Left=�6+   $��340,111,0,0q�6F   $	��Top=�6[   $��Malgun Gothic)�6s   �� 5"      $��	Last name��6   $
��Left=�6,   $��
340,45,0,0q�6G   $	��Top=�6[   $��Malgun Gothic)�6s   �� 5#      $��Email��6   $
��Left=�6(   $��152,240,0,0q�6C   $	��Top=�6X   $��Malgun Gothic)�6p   �� 5$      $
��City��6   $
��Left=�6'   $��152,174,0,0q�6B   $	��Top=�6W   $��Malgun Gothic)�6o   �� 5%      $��Address��6   $
��Left=�6*   $��152,111,0,0q�6E   $	��Top=�6Z   $��Malgun Gothic)�6r   �� 5&      -   5        $ saveEditButton��5&      $��346,251,346,151q�61   $��Save changes��6J   $��Malgun Gothic)�6a   $
��Bold"�6|   6�   �� 5'      -   5        $ 
exitButton��5'      $��639,45,53,357q�6-   $
��Exit��6D   $��Malgun Gothic)�6S   $
��Bold"�6n   6�   �� 5(      -   5        $ editSavedLabel��5(      $�� ��60   $��152,302,286,105q�6;   ���	#FF44C100$��14(�6k   $
��Bold"�6y   $��Malgun Gothic)�6�   5)      5*      �� 5+   
   -   5        $ changePasswordPanel��5+      $
	 0.95Q�62   
�������$��0,1,0,-1q�6T   .+�5,      � $	��435��6   .+�5-      G� -   5        
 G�Name$
 oldPasswordInput��5-      $��Center=�68   $��	0,140,0,0q�6U   $	��Top=�6h   $	��142��6�   $��24��6�   G� 5.      -   5        $
 newPasswordInput��5.      $��Center=�68   $��Center=�6U   $	��140��6p   $��24��6|   G� 5/      -   5        $
 confirmPasswordInput��5/      $��Center=�6<   $��	0,271,0,0q�6Y   $	��Top=�6l   $	��141��6�   $��24��6�   �� 50      -   5        $! changePasswordConfirmButton��50      $��Change password��6>   $��Center=�6X   $��	0,323,0,0q�6u   $	��Top=�6�    J� RenderTransformOrigin$ -0.429,0.202&�6�   $	��110��6�   $��30��6�   $
��Bold"�6�   $��Malgun Gothic)�6�   6
  �� 51      $��Old password��6   $
��Left=�6/   $��225,140,0,0q�6J   $	��Top=�6_   �� 52      $��New password��6   $
��Left=�6/   $��	220,0,0,0q�6J   $��Center=�6]   �� 53      $��Confirm password��6   $
��Left=�63   $��202,269,0,0q�6N   $	��Top=�6c   �� 54      -   5        $ exitButton2��54      $
��Exit��6.   $
��Left=�6=   $��
626,48,0,0q�6X   $	��Top=�6l   $	��110��6�   $��30��6�   $��Malgun Gothic)�6�   $
��Bold"�6�   �� 55      $��Change your password��6   $��Center=�67   $��0,50,0,0q�6T   $	��Top=�6f   $��16(�6~   $
��Bold"�6�   $��Malgun Gothic)�6�   �� 56      -   5        $ changedPasswordLabel��56      $�� ��66   $��158,94,150,0q�6A   $	��Top=�6W   $��Center=�6o   58      59      5:      5;      