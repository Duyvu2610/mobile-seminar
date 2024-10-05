package matcha.project.be.controller;

import lombok.RequiredArgsConstructor;
import matcha.project.be.dto.CartRequestDto;
import matcha.project.be.dto.CartResponseDto;
import matcha.project.be.dto.CategoryResponseDto;
import matcha.project.be.dto.ItemResponseDto;
import matcha.project.be.entity.ItemEntity;
import matcha.project.be.service.CartService;
import matcha.project.be.service.CategoryService;
import matcha.project.be.service.ItemService;
import org.springframework.beans.BeanUtils;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/cart")
@RequiredArgsConstructor
public class CartController {
    private final CartService cartService;

    @GetMapping
    public ResponseEntity<Object> getAllCart() {
        List<CartResponseDto> cartResponseDtos = cartService.getAllCategories().stream()
                .map(cart -> {
                    CartResponseDto cartResponseDto = new CartResponseDto();
                    BeanUtils.copyProperties(cart, cartResponseDto);
                    return cartResponseDto;
                }).toList();
        return ResponseEntity.ok(cartResponseDtos);
    }

    @PostMapping
    public ResponseEntity<Object> createCart(@RequestBody CartRequestDto cartRequestDto) {
        cartService.createCart(cartRequestDto);
        return ResponseEntity.created(null).build();
    }
}
