# WTLive
Uses Winnipeg Transit's API to display live data for bus stops and other info.

Created using Visual Studio 2019, in C#.

How to use:
1. Basic Operation:
 - Firstly, you'll need a 64-Bit Windows PC and an internet connection to use this program.
 - When the program opens, enter a valid stop number into the appropriate textbox, or use the search button to find a stop. Stop numbers can also be found on the Winnipeg Transit (WT) website, and on WT bus stop signs.
 - Click the "Go" button. You should see a list of departures on the right side of the window. However, depending on the stop you chose, and the time and day you are doing it at, you might see a message saying "Nothing to Show" instead. This indicates there are no departures to show with the given options.
 - In addition, some bus stops have extra features to them (such as BusWatch displays). If the bus stop you selected has any, they will show up in the bottom right, under "Stop Features".

2. List of Departures:
The list of departures shows several pieces of information about each departure. They are as follows, from left to right:
 - ETA: This is the estimated time that the bus will arrive at. It can be shown as either "hh:mm" or "n Min(s)". If a bus is late or early, the ETA will take that into account.
 - Bus Number: This is the number of the bus. If it shows "Bus -----" insead of "Bus ###", then the bus number is unknown.
 - Bike Rack: This indicates if the bus has a bike rack. Similar to above, if it shows "---" instead of a bike-related symbol, then it is unknown.
 - Route Number: This is the route number (or word if it is Route BLUE) the bus is operating on.
 - Destination: This the final destination the bus is operating to.
 - Late/Early: If a bus is running late or early, it will be shown on the right. For example, if a bus is 3 minutes late, it will show "(+3)" on the right, in red. 3 Minutes early would be "(-3)", in blue. 

3. Extra Options:
As you probably noticed, the Stop Number is not the only option that you can set. There are other optional settings you can set below it. They are as follows:
 - Start Time: This is the time the earliest departure in the list can be. It must be in the 24-hour format. If it is blank, the current time will be used.
 - Routes: These are the routes you want to see. If you want multiple routes, they must be comma-separated. If it is blank, all routes will be used.
 - Bus Range: This is the range of bus numbers you want to see. If they are blank, all bus numbers can be shown.
 - Bus Type: This is the type of bus want to see. If it is set to any, then any bus type can be shown.
 - Bus Length: This is the length of bus you want to see. If it is set to any, then any bus length can be shown.
 - Bike Rack: You can choose to only buses that have bike racks, don't have bike racks, or either.
 - Cancelled: You can choose to only buses that have been cancelled, hasn't been cancelled, or either.
 - Relative Time: If checked, it will change how the ETA is shown. For example, if it is 9:24 and a bus is coming at 9:27, it'll show "3 Mins" instead of "09:27". It will only do this for future departures less than the number of minutes specified.
 - Auto Refresh: If checked, then periodically it will automatically get updated departure info. The refresh interval can be changed with the textbox below. The refresh interval must be 5 seconds or higher. You can the Auto Refresh feature by either clicking the "Stop Refresh" button, or unchecking "Auto Refresh", and clicking the "Go" button.
 - Full Screen: If you click the "Go (FS)" button, then the departure list will be shown in full screen. You can exit full screen by clicking the button in the top right.
 - Reset: This will reset the program to how it was when it was opened.
 - Dark/Light Mode: This allows you to switch between Light and Dark mode.

4. Extra Features:
In addition to the list of departures, there are also some other features. They are as follows:
 - Bus On The Go: This will open a m.winnipegtransit.com On The Go page for the bus number entered in the textbox to the right.
 - Route Destinations: This will open a window showing the current final destinations a route entered in the textbox to the right goes to.
 - Nearby Stops: This will open a window showing stops within the walking distance, entered in the textbox to the right, of the currently selected stop.
 - Service Advisories: This will open a window showing the current service advisories/re-routes.
 - Transit Website: This will open a www.winnipegtransit.com page for the currently selected stop.
