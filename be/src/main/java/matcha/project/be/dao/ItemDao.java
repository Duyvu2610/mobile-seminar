package matcha.project.be.dao;

import matcha.project.be.entity.ItemEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
@Repository
public interface ItemDao  extends JpaRepository<ItemEntity, Long> {

    List<ItemEntity> findByIsRecommendedTrue();

    List<ItemEntity> findAllByOrderByAmountSoldDesc();

    List<ItemEntity> findItemEntitiesByCategoryId(Long categoryId);
}
