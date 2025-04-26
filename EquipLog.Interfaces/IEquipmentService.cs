using EquipLog.ViewModels;

namespace EquipLog.Interfaces
{
    public interface IEquipmentService
    {
        public void AddEquipment(AddEquipmentViewModel eqipmentViewModel);
        public Task<EditEquipmentViewModel> GetEquipmentForEditAsync(string equipmentId);
        public void Edit(EditEquipmentViewModel eqipmentViewModel); 
    }
}
