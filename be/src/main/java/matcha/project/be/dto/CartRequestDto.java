package matcha.project.be.dto;

import lombok.Data;

import java.io.Serial;
import java.io.Serializable;

@Data
public class CartRequestDto implements Serializable {
    @Serial
    private static final long serialVersionUID = 1L;

    private Long itemId;

    private Long quantity;

    private String itemName;

    private String itemImg;

    private Long price;
}