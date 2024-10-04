package matcha.project.be.dao;

import matcha.project.be.entity.ItemEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
@Repository
public interface ItemDao  extends JpaRepository<ItemEntity, Long> {
    List<ItemEntity> findByCategoryIdOrderByAmountSoldDesc(Long categoryId);

    List<ItemEntity> findByIsRecommendedTrue();
    List<ItemEntity> findAllByOrderByAmountSoldDesc();
    @Query("SELECT i FROM ItemEntity i WHERE i.categoryId = :categoryId")
    List<ItemEntity> findItemsByCategoryId(@Param("categoryId") Long categoryId);
}
