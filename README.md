# Vendor and Order Tracker

#### By E. Luckie ☀️

#### This webpage acts as a tool to help a bakery owner track the vendors that purchase baked goods from them and the orders belonging to those vendors.

## Technologies Used

* C#
* HTML
* Dotnet
* MSTest
* Markdown
* CSS
* Git

## Description

This webpage acts as a tool to help a bakery owner organize and keep track of their vendors and vendor orders. From the homepage, the owner has clickable links to add a vendor, add an order, view all vendors, and update an invoice's status.

**Add a new vendor:** takes the user to a form where they can enter the vendor's name, and select which type of vendor they are - business, personal, bulk business, or other. From here, they may either enter the information & click _add vendor_, or there is also clickable links to view the vendor list or return to homepage

**Add a new order:** takes the user to the list of vendors. They must select the vendor they'd like to add an order for

**View all vendors:** takes the user to the list of vendors. From there, they may choose to add a new vendor or return to the main page

**Return to main page:** takes the user back to the homepage

**Update an invoice status:** takes the user to the list of vendors. From there they must choose the vendor with an order they wish to update
##

Once at least one vendor has been added, a list of vendors will populate on the view all vendors page. There will also be a button that says _delete all vendors_ which clears the vendor list in one click

From the vendor list, the user may click on the specific vendor they wish to view/edit. That will lead them to the specific vendor's page. On that page they may add an order to the specified vendor, update the specified vendor's name or type, return to vendor list, return to main page, or delete the selected vendor in one click.

**Add a new order to {Vendor}:** takes the user to a form where they can fill out the order title, date, pastry quantity, bread quantity, and status (paid/unpaid) of the order. There is also an _add order_ button on this page. From this page, they may also select to cancel the new order, return to the vendor list, return to the main page.
* canceling the order redirects them back to the specified Vendor's page with their list of current orders

**Update {Vendor's} information:** takes the user to a form where they can fill out a new vendor name &/or update the vendor's type. Once filled out, they can click _update {Vendor}_ which will update the vendor with the new information and take them back to the vendor's page with their list of current orders. They also have clickable links to cancel the update, return to vendor list, or return to the main page
* if they choose to cancel the update which will take them back to the vendor's page with their list of current orders
##

Once at least one order is added to the vendor, the vendor's main page will populate with a numbered list of all orders showing the order title and date (clickable) and the order's total. From there, users may choose to add a new order, update the vendor's information, return to vendor list, return to main page. There is also a button to _delete {Vendor}_
* clicking the _delete {Vendor}_ button deletes the vendor and all their orders in one click
##

Clicking on a specific order directs the user to the specified order's main page where they are able to view the order details such as the title, date, quantity of each item in the order, order total, and vendor name. From there, the user may choose to update order quantities, update order status, return to {Vendor}, return to the vendor list or return to the main page. There is also a button to _delete this order_. This button will delete the specified order in one click

**Update order quantities:** takes the user to a form where they may enter new pastry & bread order quantities & click update order. Updating the order redirects them to the specified order's details page
* They may also choose to instead return to the vendor's main page, return to the full vendor list, or return to the main page

**Update order status:** takes the user to a page with radio buttons labeled paid or unpaid where they can select the updated order status and click the _update order_ button. There is also clickable links to cancel the update (which takes them back to the order details page), return to the vendor's main page, return to the vendor list, or return to the main page
* updating the status will show a page confirming that the status and has been updated and displaying the new status
* from there, the user may choose to return to the specified order's details, return to the vendor, return to the vendor list, or return to the main page

### Paths
_**/**_ splash page

_**/vendors**_ list of vendors & their orders

_**/vendors/new**_ form to add a vendor

_**/vendors/{id}**_ specified vendor's information when they haven't placed an order yet

_**/vendors/{id}/orders**_ specified vendor's list of orders

_**/vendors/{id}/update**_ form to update specified vendor's information

_**/vendors/delete**_ confirmation that specified vendor has been deleted

_**/vendors/{id}/orders/new**_ form to add a new order to vendor

_**/vendors/{vendorid}/orders/{orderid}**_ order details for specified order

_**/vendors/{vendorid}/orders/{orderid}/updateqty**_ update amounts in specified order's details

_**/orders/delete**_ delete specified order from vendor

_**/orders/deleteall**_ delete all orders from specified vendor

_**/vendors/{vendorid}/orders/{orderid}/updatestatus**_ form to update specified order's status paid/unpaid

_**/orders/statuschange**_ confirmation of order status update

## Setup/Installation Requirements

1. Clone this repository
2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory called _VendorOrderTracker_
3. In the command line, run the command ``dotnet watch run`` to compile and execute the webpage in Development mode
4. Optionally, you can run the command ``dotnet build`` to compile this webpage application without running it.

### To Run Tests
1. Navigate to this project's test directory called _VendorOrderTracker.Tests_
2. If the project hasn't already been restored, run the command ``dotnet restore`` in your computer's terminal
3. Then, in the terminal, run the command ``dotnet test`` to perform the tests and verify 100% pass-rate

## Known Bugs

* If deleting an order from the list and then attempting to view order details for a later order, path does not update properly to account for 1 less order
* ^ same issue with deleting a vendor from the list

## Stretch Plans

* Add search functionality
* Add more orderable items

## License

MIT License

Copyright (c) 2023 Luckie