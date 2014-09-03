Sort Format Tokens for CodeRush 
===================

An OCD plugin by RoryBecker :)

Sort Format Tokens is a CodeRush plugin which adds a new CodeProvider

#### Availability ####
This CodeProvider is available within the first param of any String.Format call where the string tokens are **properly** ordered **:P**

####Effect####
String Format Tokens and their corresponding parameters are rewritten.
The indices of the rewritten tokens will be, as far as possible, numerically ordered and zero based.

####Notes####
Yes.... This really is quite ridiculous... Although besides the silly OCD correction, there is at least 1 practical benefit: 

If an argument is not referenced by a String Token within the main string, then that argument will be removed from the string.Format call entirely.

This of course means that this functionality cannot be considered a Refactoring, which is why it is a CodeProvider instead.


####Examples####

#####2 Reversed Tokens#####

Before	

	var v1 = string.Format("{1} {0}", 0, 1);

After

	var v1 = string.Format("{0} {1}", 1, 0);


#####With Duplicate Tokens#####

Before	

    var v3 = string.Format("{1} {0} {1}", 1, 2);

After

    var v3 = string.Format("{0} {1} {0}", 2, 1);

#####With Format Specified#####

Before	

    var v6 = string.Format("{1:00} {0:45} {1}", 1, 2);

After

    var v6 = string.Format("{0:00} {1:45} {0}", 2, 1);

#####Item Removal#####

Before	

    var v3 = string.Format("{2} {3} {4}", 0, 1, 2, 3, 4);

After

    var v3 = string.Format("{0} {1} {2}", 2, 3, 4);
