# "Reto Wallmart" technical approach proposal

**Selected stack:**
  - Angular 11 / Bootstrap 
  - API Rest .Net Core 3.1 (C#)
  - MongoDB
  
# Overview

It's requested to build a solution that presents a product search engine simulating a "promotional search" wich consider that if the search criteria is a palindrome, the price of the returned item(s) must have a 50% off.
On the other hand, if what is entered in the search box is a number, it must search directly over the product ID but if it's an alphanumeric string, and it has more than three characters it must be searched on the "Brand" and "Description" fields using any sort of "Contains" constraint.


**The resulting solutions looks like this:**

<img src="Img/app_grid.jpg" width="80%"  />


...As you can see in the folowing images, as it's requested, if a search criteria is a palindrome (in this case the search was triggered with '101' which is a palindrome), the product price must be returned with a 50% off. The price difference can be checked in the original product listing shown in the first image and the specific search result on the second image:

<img src="Img/app_grid_page_11.jpg" width="75%"  /> <img src="Img/app_grid_palindrome_result.jpg" width="75%"  />

**NOTE: the prices will be upper rounded anytime the discount application doesn't give an exact value**
