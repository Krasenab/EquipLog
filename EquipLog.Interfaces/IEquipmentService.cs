using EquipLog.ViewModels;

namespace EquipLog.Interfaces
{
    public interface IEquipmentService
    {
        public void AddEquipmentAsync(AddEquipmentViewModel eqipmentViewModel);
    }
}
