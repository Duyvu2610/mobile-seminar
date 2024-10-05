package matcha.project.be.dto;

import lombok.Data;

@Data
public class ItemResponseDto {
    private Long id;
    private String name;
    private String brand;
    private Double price;
    private String imageUrl;
    private Long amountSold;
    private Boolean isRecommended;
}
