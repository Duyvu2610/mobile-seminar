package matcha.project.be.entity;

import jakarta.persistence.*;
import lombok.Data;

@Data
@Entity
@Table(name = "cart")
public class CartEntity {

    @Id
    @Column(name = "item_id")
    private Long itemId;

    @Column(name = "item_name")
    private String itemName;

    @Column(name = "item_img")
    private String itemImg;

    @Column(name = "quantity")
    private Long quantity;

    @Column(name = "price")
    private Long price;
}
