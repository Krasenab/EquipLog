using EquipLog.ViewModels;

namespace EquipLog.Interfaces
{
    public interface IEquipmentService
    {
        public Task<List<EquipmentListItemViewModel>> GetAllFilteredEquipment(string searchTerm,string category); 
        public Task<List<EquipmentListItemViewModel>> GetAllEquipmentAsync();
        public void AddEquipment(AddEquipmentViewModel eqipmentViewModel);
        public Task<EditEquipmentViewModel> GetEquipmentForEditAsync(string equipmentId);
        public void Edit(EditEquipmentViewModel eqipmentViewModel); 
    }
}
