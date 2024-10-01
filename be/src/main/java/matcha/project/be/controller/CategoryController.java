package matcha.project.be.controller;

import lombok.RequiredArgsConstructor;
import matcha.project.be.dto.CategoryResponseDto;
import matcha.project.be.service.CategoryService;
import org.springframework.beans.BeanUtils;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/category")
@RequiredArgsConstructor
public class CategoryController {
    private final CategoryService categoryService;

    @GetMapping
    public ResponseEntity<Object> getAllCategories() {
        List<CategoryResponseDto> categories = categoryService.getAllCategories().stream()
                .map(category -> {
                    CategoryResponseDto categoryResponseDto = new CategoryResponseDto();
                    BeanUtils.copyProperties(category, categoryResponseDto);
                    return categoryResponseDto;
                }).toList();
        return ResponseEntity.ok(categories);
    }
}