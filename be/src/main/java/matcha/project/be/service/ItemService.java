package matcha.project.be.service;

import lombok.RequiredArgsConstructor;
import matcha.project.be.dao.ItemDao;
import matcha.project.be.entity.ItemEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class ItemService {
    private  final ItemDao itemDao;
    public List<ItemEntity> getAllItems() {
        return  itemDao.findAll();
    }
    public List<ItemEntity> getBestSellingItems() {


        return itemDao.findAllByOrderByAmountSoldDesc();
    }
    public List<ItemEntity> getBestSellingItemsByCategory(Long categoryId) {
        return itemDao.findByCategoryIdOrderByAmountSoldDesc(categoryId);
    }
    public List<ItemEntity> getRecommendedItems() {
        return itemDao.findByIsRecommendedTrue();
    }





}
