package matcha.project.be.service;

import lombok.AccessLevel;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;
import matcha.project.be.dao.ItemDao;
import matcha.project.be.entity.ItemEntity;
import matcha.project.be.enums.ItemError;
import matcha.project.be.exception.ItemException;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
@FieldDefaults(level = AccessLevel.PRIVATE, makeFinal = true)
public class ItemService {
    ItemDao itemDao;

    public ItemEntity getItemById(Long id) {
        return itemDao.findById(id).orElseThrow(() -> new ItemException(ItemError.ITEM_NOT_FOUND));
    }
}