package matcha.project.be.service;

import lombok.AccessLevel;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;
import matcha.project.be.dao.ItemDao;
import matcha.project.be.dto.ItemResponseDto;
import matcha.project.be.entity.ItemEntity;
import matcha.project.be.enums.ItemError;
import matcha.project.be.exception.ItemException;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
@FieldDefaults(level = AccessLevel.PRIVATE, makeFinal = true)
public class ItemService {
    ItemDao itemDao;

    public ItemEntity getItemById(Long id) {
        return itemDao.findById(id).orElseThrow(() -> new ItemException(ItemError.ITEM_NOT_FOUND));
    }



    public List<ItemEntity> getBestSellingItemsByCategory(Long categoryId) {
        return itemDao.findByCategoryIdOrderByAmountSoldDesc(categoryId);
    }

    public List<ItemEntity> getRecommendedItems() {
        return itemDao.findByIsRecommendedTrue();
    }

    public List<ItemEntity> getBestSellingItems() {
            return  itemDao.findAllByOrderByAmountSoldDesc();
    }

    public List<ItemEntity> getItemsByCategoryId(Long categoryId) {
        return itemDao.findItemEntitiesByCategoryId(categoryId);
    }
}
