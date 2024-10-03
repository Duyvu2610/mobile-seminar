package matcha.project.be.controller;

import lombok.RequiredArgsConstructor;
import matcha.project.be.entity.ItemEntity;
import matcha.project.be.service.ItemService;
import org.springframework.http.ResponseEntity;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/items")
@RequiredArgsConstructor
public class ItemController {
        private final ItemService itemService;

        @GetMapping("/best-selling")
        public ResponseEntity<List<ItemEntity>> getBestSelling() {
            List<ItemEntity> bestSellingItems = itemService.getBestSellingItems();
            return  ResponseEntity.ok(bestSellingItems);

        }
        @GetMapping("/best-selling/{categoryId}")
        public ResponseEntity<List<ItemEntity>> getBestSellingItemsByCategory(@PathVariable Long categoryId) {
        List<ItemEntity> bestSellingItems = itemService.getBestSellingItemsByCategory(categoryId);
        return ResponseEntity.ok(bestSellingItems);
     }
        @GetMapping("/all")
        public ResponseEntity<List<ItemEntity>> getAllItems() {
            List<ItemEntity> allItems = itemService.getAllItems();
            return  ResponseEntity.ok(allItems);
        }
    @GetMapping("/recommended")
    public ResponseEntity<List<ItemEntity>> getRecommendedItems() {
        List<ItemEntity> recommendedItems = itemService.getRecommendedItems();
        return ResponseEntity.ok(recommendedItems);
    }

}
