package matcha.project.be.service;

import lombok.RequiredArgsConstructor;
import matcha.project.be.dao.CartDao;
import matcha.project.be.dao.CategoryDao;
import matcha.project.be.dto.CartRequestDto;
import matcha.project.be.entity.CartEntity;
import matcha.project.be.entity.CategoryEntity;
import org.springframework.beans.BeanUtils;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class CartService {
    private final CartDao cartDao;

    public List<CartEntity> getAllCategories() {
        return cartDao.findAll();
    }

    public void createCart(CartRequestDto cartRequestDto) {
        final CartEntity cartEntity = cartDao.findById(cartRequestDto.getItemId()).orElse(new CartEntity());
        cartEntity.setItemId(cartRequestDto.getItemId());
        cartEntity.setItemName(cartRequestDto.getItemName());
        cartEntity.setItemImg(cartRequestDto.getItemImg());
        cartEntity.setPrice(cartRequestDto.getPrice());
        if (cartEntity.getQuantity() == null) {
            cartEntity.setQuantity(1L);
        } else {
            cartEntity.setQuantity(cartRequestDto.getQuantity() + cartEntity.getQuantity());
        }
        cartDao.save(cartEntity);
    }

}
