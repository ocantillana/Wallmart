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

