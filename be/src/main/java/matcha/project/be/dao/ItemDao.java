package matcha.project.be.dao;

import matcha.project.be.entity.ItemEntity;
import org.springframework.data.repository.CrudRepository;

public interface ItemDao extends CrudRepository<ItemEntity, Long> {
}
