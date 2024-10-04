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

    public List<ItemResponseDto> getItemsByCategoryId(Long categoryId) {
        List<ItemEntity> items = itemDao.findItemsByCategoryId(categoryId);  // Lấy dữ liệu từ DB
        return items.stream()
                .map(this::convertToItemResponseDto)  // Chuyển đổi từ Entity sang DTO
                .collect(Collectors.toList());
    }

    // Chuyển đổi từ ItemEntity sang ItemResponseDto
    private ItemResponseDto convertToItemResponseDto(ItemEntity itemEntity) {
        ItemResponseDto dto = new ItemResponseDto();
        dto.setId(itemEntity.getId());
        dto.setName(itemEntity.getName());
        dto.setBrand(itemEntity.getBrand());
        dto.setPrice(itemEntity.getPrice());
        dto.setImageUrl(itemEntity.getImageUrl());
        dto.setAmountSold(itemEntity.getAmountSold());
        dto.setIsRecommended(itemEntity.getIsRecommended());
        return dto;
    }
}