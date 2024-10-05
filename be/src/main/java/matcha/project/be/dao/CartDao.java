package matcha.project.be.dao;

import matcha.project.be.entity.CartEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface CartDao extends JpaRepository<CartEntity, Long> {

}
