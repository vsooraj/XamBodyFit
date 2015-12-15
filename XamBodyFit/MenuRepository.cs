using System.Collections.Generic;


namespace XamBodyFit
{
    public class MenuRepository
    {
        public static Dictionary<string, Menu> elements = BuildDictionary();

        private static Dictionary<string, Menu> BuildDictionary()
        {
            var menuElements = new Dictionary<string, Menu>();

            AddToDictionary(menuElements, "Catalog", "http://shop.sportsauthority.com/search?w=catalog", 0);
            AddToDictionary(menuElements, "StoreLocator", "http://stores.sportsauthority.com/", 1);
            AddToDictionary(menuElements, "Exit", "", 2);


            return menuElements;
        }
        private static void AddToDictionary(Dictionary<string, Menu> elements, string symbol, string name, int atomicNumber)
        {
            Menu theElement = new Menu();

            theElement.Item = symbol;
            theElement.Url = name;
            theElement.AtomicNumber = atomicNumber;

            elements.Add(key: theElement.Item, value: theElement);
        }
        public static List<string> GetMenuItems()
        {
            List<string> leftItems = new List<string>();
            foreach (KeyValuePair<string, Menu> kvp in elements)
            {
                leftItems.Add(kvp.Key);
            }
            return leftItems;

        }
        public static Dictionary<string, string> GetMenuItemsWithUri()
        {
            Dictionary<string, string> navigationItems = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Menu> kvp in elements)
            {
                navigationItems.Add(kvp.Key, kvp.Value.Url);
            }
            return navigationItems;

        }
    }
}