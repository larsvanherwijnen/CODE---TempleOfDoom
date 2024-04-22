using DataReader.DTO;
using GameLib.Decorators.ItemDecorators;
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models;
using GameLib.Models.Items;

namespace DataReader.Factories;

public class ItemFactory
{
    public IItem CreateItem(ItemsDto itemDto)
    {
        Coords coords = new Coords(itemDto.x, itemDto.y);
        IItem item = null;
        List<string> decorators = new List<string>();
        
        switch (itemDto.type)
        {
            case "boobytrap": 
                item = new BoobietrapItem(coords);
                decorators.Add("damage");
                break;
            case "disappearing boobytrap":
                item = new BoobietrapItem(coords);
                decorators.Add("damage");
                decorators.Add("disappearing");
                break;
            case "sankara stone":
                item = new SankaraStoneItem(coords);
                decorators.Add("disappearing");
                decorators.Add("pickupable");
                break;
            case "key":
                item = new KeyItem(coords, itemDto.color);
                decorators.Add("disappearing");
                decorators.Add("pickupable");
                break;
            case "pressure plate":
                item = new PressurePlateItem(coords);
                break;
            default:
                throw new NotImplementedException("Invalid item type");
        }

        return ApplyDerocators(item, decorators, itemDto);
    }
    
    
    private IItem ApplyDerocators(IItem item, List<string> decorators, ItemsDto itemsDto)
    {
        foreach (string decorator in decorators)
        {
            switch (decorator)
            {
                case "damage":
                    item = new DamageItemDecorator(item, itemsDto.damage);
                    break;
                case "disappearing":
                    item = new DisappearingItemDerocator(item);
                    break;
                case "pickupable":
                    item = new PickupableItemDerocator(item);
                    break;
            }
        }
        
        return item;
    }
}