package matcha.project.be.controller;

import lombok.AccessLevel;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;
import matcha.project.be.dto.ItemResponseDto;
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
@FieldDefaults(level = AccessLevel.PRIVATE, makeFinal = true)
public class ItemController {
    ItemService itemService;

    @GetMapping("/{id}")
    public ResponseEntity<ItemEntity> getItemById(@PathVariable Long id) {
        return ResponseEntity.ok(itemService.getItemById(id));
    }
    @GetMapping("/best-selling")
    public ResponseEntity<List<ItemEntity>> getBestSellingItems() {
        List<ItemEntity> bestSellingItems = itemService.getBestSellingItems();
        return ResponseEntity.ok(bestSellingItems);
    }

    @GetMapping("/recommended")
    public ResponseEntity<List<ItemEntity>> getRecommendedItems() {
        List<ItemEntity> recommendedItems = itemService.getRecommendedItems();
        return ResponseEntity.ok(recommendedItems);
    }

}
